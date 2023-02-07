using FinalProyect_MaxiPrograma_LVL3.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Error || Page is Register || Page is MyProfile))
            {
                if (!Security.isLogged(Session["User"]))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UserClass user = (UserClass)Session["User"];
                    imgProfile.ImageUrl = user.UrlImagen + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }
            else
            {
                if (Security.isLogged(Session["User"]))
                {
                    UserClass user = (UserClass)Session["User"];
                    imgProfile.ImageUrl = user.UrlImagen +"?v=" + DateTime.Now.Ticks.ToString();
                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void imgProfile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}