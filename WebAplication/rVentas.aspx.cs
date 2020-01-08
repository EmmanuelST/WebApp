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
            detalles = new List<VentaDetalles>();
            venta = new Ventas();

            detalles.Add(new VentaDetalles()
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

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioVentas db = new RepositorioVentas();
            Ventas ventas = new Ventas();

           /* try
            {*/
                ventas = LlenarClase();

                if (db.Guardar(ventas))
                {
                    Utilidades.Mensaje("Guardado", this, GetType());
                    Limpiar();
                    return;
                }


                Utilidades.Mensaje("No se pudo guardar", this, GetType());



            //}
            /*catch (Exception)
            {
                throw;
            }*/



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
            ComentarioTextBox.Text = string.Empty;
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
            venta.CalcularTotal();
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}