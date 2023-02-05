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
            if (!IsPostBack)
            {
                imgNewImage.ImageUrl = "./Images/noImage.png";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            UserClass user = new UserClass();
            UserNegocio negocio = new UserNegocio();
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                           + "@"
                           + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            lblWarningConfirm.Visible = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, pattern))
            {
                lblWarningEmail.Visible = true;
                lblWarningEmail.Text = "Please, write a valid Email.";
            }
            else if (txtPassword.Text == "")
            {
                lblWarningEmail.Visible = false;
                lblWarningPass.Visible = true;
                lblWarningPass.Text = "Please,write a valid Password";
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblWarningPass.Visible = false;
                lblWarningConfirm.Visible = true;
                lblWarningConfirm.Text = "Password didn't match";
            }
            else
            {
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                string imagePath = Server.MapPath("./Images/");
                user.UrlImagen = "toModify";
                if (txtName.Text == "")
                    user.UserName = "No Name";
                else
                    user.UserName = txtName.Text;
                if (txtSurname.Text == "")
                    user.UserSurname = "No Surname";
                else
                    user.UserSurname = txtPassword.Text;
                int idUser = negocio.register(user);
                fupImage.PostedFile.SaveAs(imagePath + "profile-" + idUser + ".png");
                negocio.correctImageUrl(idUser);

                Session.Add("Error", "Register Complete succesfully, please login.");
                Response.Redirect("Error.aspx");
            }
        }
    }
}