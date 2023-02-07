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
                imgNewImage.ImageUrl = user.UrlImagen +"?v=" + DateTime.Now.Ticks.ToString();
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
            lblNewPass.Visible = false;
            lblNewImage.Visible = false;
            lblPass.Visible = false;
            if (pass == user.Password)
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblPass.Visible = false;
                    lblNewPass.Visible = true;
                    lblNewPass.Text = "Password don't match.";
                }
                else
                {
                    pass = txtPassword.Text;
                    pass = txtPassword.Text;
                    if (fupImage.HasFile)
                    {
                        // Verifica que el archivo sea una imagen
                        if (!fupImage.FileName.EndsWith(".jpg") && !fupImage.FileName.EndsWith(".jpeg") && !fupImage.FileName.EndsWith(".png"))
                        {
                            lblImagenError.Visible = true;
                            lblImagenError.Text = "Please upload a valid image";
                            return;
                        }
                        string imagePath = Server.MapPath("~/Images/");
                        string fileName = "profile-" + user.Id + ".png";
                        if (File.Exists(imagePath + fileName))
                        {
                            File.Delete(imagePath + fileName);
                        }
                        fupImage.SaveAs(imagePath + fileName);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                        Response.Cache.SetNoStore();
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
            else
            {
                lblNewPass.Visible = false;
                lblPass.Visible = true;
                lblPass.Text = "Invalid Password.";
            }
        }
    }
}