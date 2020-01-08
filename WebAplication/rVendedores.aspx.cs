using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAplication.BLL;
using WebAplication.Entidades;

namespace WebAplication
{
    public partial class rVendedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();
            Vendedores vendedores = LlenarClase();

            try
            {

                vendedores.FechaRegistro = DateTime.Now;

                if (db.Guardar(vendedores))
                {
                    string script = "alert(\"Guardado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }
                else
                {

                    string script = "alert(\"No se pudo guardar\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                }




            }
            catch (Exception)
            {
                throw;
            }
        }

        private Vendedores LlenarClase()
        {
            Vendedores vendedor = new Vendedores()
            {
                VendedorId = int.Parse(IdTextBoxt.Text),
                Nombre = NombreTextBox.Text,
                Direccion = DireccionTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                Cedula = CedulaTextBox.Text,
                FechaNacimiento = NacimientoCalendar.SelectedDate
            };


            return vendedor;

        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdTextBoxt.Text = "0";
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            NacimientoCalendar.SelectedDate = DateTime.Now;

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();
            Vendedores vendedores;


            try
            {
                vendedores = db.Buscar(int.Parse(IdTextBoxt.Text));

                if (vendedores == null)
                {
                    string script = "alert(\"No se existe\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                if (db.Elimimar(vendedores.VendedorId))
                {
                    string script = "alert(\"Eliminado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"No se pudo eliminar\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();

            try
            {

                Vendedores vendedores = db.Buscar(int.Parse(IdTextBoxt.Text));

                if (vendedores == null)
                {
                    string script = "alert(\"No se encontro\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                LlenarCampos(vendedores);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LlenarCampos(Vendedores vendedores)
        {
            IdTextBoxt.Text = vendedores.VendedorId.ToString();
            NombreTextBox.Text = vendedores.Nombre;
            DireccionTextBox.Text = vendedores.Direccion;
            CedulaTextBox.Text = vendedores.Cedula;
            TelefonoTextBox.Text = vendedores.Telefono;
            NacimientoCalendar.SelectedDate = vendedores.FechaNacimiento;
        }
    }
}