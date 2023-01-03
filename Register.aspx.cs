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
                
                UserClass user = new UserClass(txtEmail.Text, txtPassword.Text, false);
                UserNegocio negocio = new UserNegocio();
                if (inpImage.PostedFile.FileName != "")
                {
                    string imagePath = Server.MapPath("./Images/");
                    inpImage.PostedFile.SaveAs(imagePath + "profile-" + user.Id + ".jpg");
                    user.UrlImagen = "profile-" + user.Id + ".jpg";
                }
                else
                {
                    user.UrlImagen = "noImage.jpg";
                }
                user.UserName = txtName.Text;
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