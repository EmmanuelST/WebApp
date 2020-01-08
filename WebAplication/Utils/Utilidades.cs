using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebAplication.Utils
{
    public class Utilidades
    {


        public static void Mensaje(string mensaje, Page page ,Type type)
        {
            string script = "alert(\""+mensaje+"\");";
            ScriptManager.RegisterStartupScript(page, type,
                                  "ServerControlScript", script, true);
        }
    }
}