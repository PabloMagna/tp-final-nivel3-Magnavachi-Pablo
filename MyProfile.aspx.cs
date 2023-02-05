using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using FinalProyect_MaxiPrograma_LVL3.negocio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserClass user = (UserClass)Session["user"];
                if (user.TypeUser == typeUser.Admin)
                {
                    Session.Add("Error", "You don't have permission to modify this profile. Please Loguin with User(no admin) to access this page.");
                    Response.Redirect("Error.aspx");
                }
                imgNewImage.ImageUrl = user.UrlImagen;
                if (user.UserName == null)
                    txtName.Text = "";
                else
                    txtName.Text = user.UserName;
                if (user.UserSurname == null)
                    txtSurname.Text = "";
                else
                    txtSurname.Text = user.UserSurname;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            UserClass user = (UserClass)Session["user"];
            user.UserName = txtName.Text;
            user.UserSurname = txtSurname.Text;
            string pass = txtOldPass.Text;
            if (pass == "")
            {
                pass = user.Password;
            }
            else if (pass == user.Password)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    pass = txtPassword.Text;
                }
                else
                {
                    Session.Add("Error", "Password didn't match");
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                Session.Add("Error", "Incorrect  Pasword");
                Response.Redirect("Error.aspx");
            }
            if (fupImage.HasFile)
            {
                string imagePath = Server.MapPath("~/Images/");
                string fileName = "profile-" + user.Id + Path.GetExtension(fupImage.FileName);
                if (File.Exists(imagePath + fileName))
                {
                    File.Delete(imagePath + fileName);
                }
                fupImage.SaveAs(imagePath + fileName);
            }
            if (user.UrlImagen == null)
                negocio.correctImageUrl(user.Id);
            user.UserName = txtName.Text;
            user.UserSurname = txtSurname.Text;
            negocio.modify(user);
            Session["user"] = user;
            Response.Redirect("Default.aspx", false);

        }
    }
}