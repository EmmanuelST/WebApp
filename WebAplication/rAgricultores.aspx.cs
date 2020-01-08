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
    public partial class rAgricultores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();
            Agricultores agricultor = LlenarClase();

            try
            {

                agricultor.FechaRegistro = DateTime.Now;

                if (db.Guardar(agricultor))
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

        private Agricultores LlenarClase()
        {
            Agricultores agricultor = new Agricultores()
            {
                AgricultorId = int.Parse(IdTextBoxt.Text),
                Nombre = NombreTextBox.Text,
                Direccion = DireccionTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                Cedula = CedulaTextBox.Text,
                FechaNacimiento = NacimientoCalendar.SelectedDate
            };


            return agricultor;

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
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();
            Agricultores agricultor;


            try
            {
                agricultor = db.Buscar(int.Parse(IdTextBoxt.Text));

                if (agricultor == null)
                {
                    string script = "alert(\"No se existe\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                if (db.Elimimar(agricultor.AgricultorId))
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

        private void LlenarCampos(Agricultores agricultor)
        {
            IdTextBoxt.Text = agricultor.AgricultorId.ToString();
            NombreTextBox.Text = agricultor.Nombre;
            DireccionTextBox.Text = agricultor.Direccion;
            CedulaTextBox.Text = agricultor.Cedula;
            TelefonoTextBox.Text = agricultor.Telefono;
            NacimientoCalendar.SelectedDate = agricultor.FechaNacimiento;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();

            try
            {

                Agricultores agricultor = db.Buscar(int.Parse(IdTextBoxt.Text));

                if (agricultor == null)
                {
                    string script = "alert(\"No se encontro\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                LlenarCampos(agricultor);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}