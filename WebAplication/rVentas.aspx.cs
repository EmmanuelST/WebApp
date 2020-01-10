using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAplication.BLL;
using WebAplication.Entidades;
using WebAplication.Utils;

namespace WebAplication
{
    public partial class rVentas : System.Web.UI.Page
    {

        public List<VentaDetalles> detalles;
        public Ventas venta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["Venta"] = new Ventas();
                
            }

            detalles = new List<VentaDetalles>();
            venta = new Ventas();

            venta = (Ventas)ViewState["Venta"];
            detalles = venta.Detalles;//(VentaDetalles)ViewState["Lista"];

            /*if(!Page.IsPostBack)
            {
                base.ViewState["Ventas"] = new Ventas();
            }
            
            detalles = new List<VentaDetalles>();
            venta = new Ventas();

            if(base.ViewState["Venta"] != null)
            {
                venta = (Ventas)base.ViewState["Venta"];
                detalles = venta.Detalles;
            }*/

            //CargarGrip();


            /*detalles.Add(new VentaDetalles()
            {
                IdVentaDetalle = 0,
                IdVenta = 0,
                IdProducto = 5,
                Cantidad = 2,
                Precio = 500,
                SubTotal = 50
            });

            detalles.Add(new VentaDetalles()
            {
                IdVentaDetalle = 0,
                IdVenta = 0,
                IdProducto = 2,
                Cantidad = 22,
                Precio = 502,
                SubTotal = 520
            });

            venta.Detalles = detalles;
            venta.Total = Ventas.CalcularTotal(detalles);*/
        }



        protected void ClienteBuscarButton_Click(object sender, EventArgs e)
        {
            Clientes cliente;
            try
            {
                if ((cliente = BuscarClientes(int.Parse(IdClienteTextBox.Text))) == null)
                {
                    Utilidades.Mensaje("No se encontro", this, GetType());
                    return;
                }

                ClienteTextBox.Text = cliente.Nombre;

                IdClienteTextBox.Focus();


            }
            catch (Exception)
            {
                throw;
            }

        }

        private Clientes BuscarClientes(int id)
        {
            Clientes cliente = null;

            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            try
            {
                cliente = db.Buscar(id);

            }
            catch (Exception)
            {
                throw;
            }



            return cliente;
        }

        private Vendedores BuscarVendedor(int id)
        {
            Vendedores vendedor = null;

            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();

            try
            {
                vendedor = db.Buscar(id);

            }
            catch (Exception)
            {
                throw;
            }



            return vendedor;
        }

        protected void VendedorBuscarButton_Click(object sender, EventArgs e)
        {
            Vendedores vendedor;
            try
            {
                if ((vendedor = BuscarVendedor(int.Parse(IdVendedorTextBox.Text))) == null)
                {
                    Utilidades.Mensaje("No se encontro", this, GetType());
                    return;
                }

                VendedorTextBox.Text = vendedor.Nombre;
                IdVendedorTextBox.Focus();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BuscarProductoButton_Click(object sender, EventArgs e)
        {
            Productos producto;
            try
            {
                if ((producto = BuscarProducto(int.Parse(ProductoIdTextBox.Text))) == null)
                {
                    Utilidades.Mensaje("No se encontro", this, GetType());
                    return;
                }

                ProductoNombreTextBox.Text = producto.Descripcion;
                ExistenciaTextBox.Text = producto.Existencia.ToString();
                
                ProductoIdTextBox.Focus();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private Productos BuscarProducto(int id)
        {
            Productos producto = null;

            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            try
            {
                producto = db.Buscar(id);

            }
            catch (Exception)
            {
                throw;
            }



            return producto;
        }



        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            try
            {
                Productos producto = null;
                producto = db.Buscar(int.Parse(ProductoIdTextBox.Text));

                if(producto == null)
                {
                    Utilidades.Mensaje("No se encontro el producto",this,GetType());
                    return;
                }

                detalles.Add(new VentaDetalles()
                {
                    IdProducto = producto.IdProductos,
                    IdVenta = 0,
                    IdVentaDetalle = 0,
                    Cantidad = decimal.Parse(CantidadTextBox.Text),
                    Precio = producto.Precio,
                    SubTotal = decimal.Parse(CantidadTextBox.Text) * producto.Precio

                });

            }catch(Exception)
            {
                throw;
            }


            venta.Detalles = detalles;
            venta.Total = Ventas.CalcularTotal(detalles);
            ViewState["Venta"] = venta;
            CargarGrip();
            base.ViewState["Ventas"] = venta;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioVentas db = new RepositorioVentas();
            Ventas ventas = new Ventas();

            try
            {
                ventas = LlenarClase();

                if (db.Guardar(ventas))
                {
                    Utilidades.Mensaje("Guardado", this, GetType());
                    Limpiar();
                    return;
                }


                Utilidades.Mensaje("No se pudo guardar", this, GetType());



            }
            catch (Exception)
            {
                throw;
            }



        }

        private Ventas LlenarClase()
        {

            Ventas venta = new Ventas();

            try
            {
                venta.IdVenta = int.Parse(IdVentaTextBoxt.Text);
                venta.Fecha = FechaCalendar.SelectedDate;
                venta.IdCliente = int.Parse(IdClienteTextBox.Text);
                venta.IdVendedor = int.Parse(IdVendedorTextBox.Text);
                venta.TipoVeta = TipoVentaDropDownList.SelectedValue;
                venta.TasaInteres = decimal.Parse(InteresTextBox.Text);
                venta.HastaFecha = VencimientoCalendar.SelectedDate;
                venta.Detalles = detalles;
                venta.Total = decimal.Parse(TotalTextBox.Text);
                //todo: Realizar el registro de usuario
                venta.IdUsuario = 0;
                venta.Comentario = ComentarioTextBox.Text;

            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                venta.Total = decimal.Parse(TotalTextBox.Text);
            }
            catch (Exception) { throw; }

            return venta;
        }

        private void Limpiar()
        {
            IdVentaTextBoxt.Text = "0";
            FechaCalendar.SelectedDate = DateTime.Now;
            IdClienteTextBox.Text = "0";
            ClienteTextBox.Text = string.Empty;
            IdVendedorTextBox.Text = "0";
            VendedorTextBox.Text = string.Empty;
            TipoVentaDropDownList.SelectedValue = "Contado";
            InteresTextBox.Text = "0";
            VencimientoCalendar.SelectedDate = DateTime.Now;
            ProductoIdTextBox.Text = "0";
            ProductoNombreTextBox.Text = string.Empty;
            CantidadTextBox.Text = "0";
            detalles = new List<VentaDetalles>();
            ComentarioTextBox.Text = "Nada";
            ActualizarLista();
            CargarGrip();
            InteresTextBox.ReadOnly = true;
            VencimientoCalendar.Enabled = false;
        }

        private void CargarGrip()
        {
            ProductosGridView.DataSource = null;
            ProductosGridView.DataSource = detalles;
            ProductosGridView.DataBind();
        }

        private void ActualizarLista()
        {
            venta.Detalles = detalles;
            venta.Total = Ventas.CalcularTotal(detalles);
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void FechaCalendar_SelectionChanged(object sender, EventArgs e)
        {
            FechaCalendar.Focus();
        }

        protected void VencimientoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            VencimientoCalendar.Focus();
        }

        protected void FechaCalendar_Load(object sender, EventArgs e)
        {
            
        }

        protected void ProductosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ProductosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EliminarButton")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                detalles.RemoveAt(indice);
                venta.Detalles = detalles;

                Utilidades.Mensaje("Llego",this,GetType());
                ViewState["Venta"] = venta;
                CargarGrip();
                    
            }
        }
    }
}