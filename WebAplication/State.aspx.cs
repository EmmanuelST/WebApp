using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAplication
{
    public partial class State : System.Web.UI.Page
    {
        decimal cont;

        protected void Page_Load(object sender, EventArgs e)
        {
            cont = 0;

            if(!Page.IsPostBack)
            {
                ViewState["Prueba"] = new decimal();
            }

            cont = (decimal)ViewState["Prueba"];

            NumeroTextBox.Text = cont.ToString();
        }

        protected void AumentarButton_Click(object sender, EventArgs e)
        {
            cont++;
            ViewState["Prueba"] = cont;
            NumeroTextBox.Text = cont.ToString();
                

        }
    }
}