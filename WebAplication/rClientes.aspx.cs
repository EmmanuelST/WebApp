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
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente = LlenarClase();

            try
            {

                cliente.FechaRegistro = DateTime.Now;

                if(db.Guardar(cliente))
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

            }catch(Exception)
            {
                throw;
            }

        }

        private Clientes LlenarClase()
        {
            Clientes cliente = new Clientes()
            { 
                ClienteId = int.Parse(IdTextBoxt.Text),
                Nombre = NombreTextBox.Text,
                Direccion = DireccionTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                Cedula = CedulaTextBox.Text,
                FechaNacimiento = NacimientoCalendar.SelectedDate
            };


            return cliente;

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

            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente;


            try
            {
                cliente = db.Buscar(int.Parse(IdTextBoxt.Text));

                if (cliente == null)
                {
                    string script = "alert(\"No se existe\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                if(db.Elimimar(cliente.ClienteId))
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
                

            }catch(Exception)
            {
                throw;
            }

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            try
            {

                Clientes cliente = db.Buscar(int.Parse(IdTextBoxt.Text));

                if(cliente == null)
                {
                    string script = "alert(\"No se encontro\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    return;
                }

                LlenarCampos(cliente);

            }catch(Exception)
            {
                throw;
            }

        }

        private void LlenarCampos(Clientes cliente)
        {
            IdTextBoxt.Text = cliente.ClienteId.ToString();
            NombreTextBox.Text = cliente.Nombre;
            DireccionTextBox.Text = cliente.Direccion;
            CedulaTextBox.Text = cliente.Cedula;
            TelefonoTextBox.Text = cliente.Telefono;
            NacimientoCalendar.SelectedDate = cliente.FechaNacimiento;
        }
    }
}