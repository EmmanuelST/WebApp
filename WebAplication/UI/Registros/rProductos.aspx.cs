using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAplication.BLL;
using WebAplication.DAL;
using WebAplication.Entidades;
using Xceed.Wpf.Toolkit;

namespace WebAplication.UI.Registros
{
    public partial class rProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> Unidades = new List<string>();

            Unidades.Add("Libras");
            Unidades.Add("Litros");
            Unidades.Add("Fundas");


            UnidadMedidaDropDownList.DataSource = Unidades;

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            Productos producto = new Productos();
            producto = LlenarClase();

            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            try
            {

                if(db.Guardar(producto))
                {
                    string script = "alert(\"Guardado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    Limpiar();
                }
                else
                {
                    string script = "alert(\"No se pudo guardar\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }


            }catch(Exception)
            {
                throw;
            }

        }

        private Productos LlenarClase()
        {
            Productos producto = new Productos()
            {
                IdProductos = int.Parse(IdTextBoxt.Text),
                Descripcion = DescripcionTextBox.Text,
                Precio = decimal.Parse(PrecioTextBox.Text),
                Costo = decimal.Parse(CostoTextBox.Text),
                Existencia = int.Parse(ExistenciaTextBox.Text),
                FechaCreacion = DateTime.Now,
                IdUsuario = 0,
                Observacion = ObservacionesTextBox.Text,
                UnidadMedida = UnidadMedidaDropDownList.SelectedValue

                
            };


            return producto;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            try
            {
                Productos producto = db.Buscar(int.Parse(IdTextBoxt.Text));

                if(producto == null)
                {
                    string script = "alert(\"No existe el producto\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                if(db.Elimimar(producto.IdProductos))
                {
                    string script = "alert(\"Eliminado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    Limpiar();
                }
                


            }catch(Exception)
            {
                throw;
            }


        }


        private void Limpiar()
        {
            IdTextBoxt.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ObservacionesTextBox.Text = string.Empty;
            UnidadMedidaDropDownList.SelectedValue = "Sacos";
            ExistenciaTextBox.Text = string.Empty;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            try
            {

                LlenarCampos(db.Buscar(int.Parse(IdTextBoxt.Text)));


            }catch(Exception)
            {
                throw;
            }

        }

        private void LlenarCampos(Productos producto)
        {
            IdTextBoxt.Text = producto.IdProductos.ToString();
            DescripcionTextBox.Text = producto.Descripcion;
            PrecioTextBox.Text = producto.Precio.ToString();
            CostoTextBox.Text = producto.Costo.ToString();
            ObservacionesTextBox.Text = producto.Observacion.ToString();
            UnidadMedidaDropDownList.SelectedValue = producto.UnidadMedida;
            ExistenciaTextBox.Text = producto.Existencia.ToString();

        }
    }
}