using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using FinalProyect_MaxiPrograma_LVL3.negocio;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                UserClass user = new UserClass( txtPassword.Text,txtEmail.Text, false);
                UserNegocio negocio = new UserNegocio();
                negocio.register(user);

                // Redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session["Error"] = "Passwords do not match.";
                Response.Redirect("Error.aspx");
            }
        }
    }
}