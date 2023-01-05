﻿using System;
using System.Collections.Generic;
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
            UserClass user = (UserClass)Session["user"];
            txtName.Text = user.UserName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            UserClass user = (UserClass)Session["user"];
            user.UserName = txtName.Text;
            string pass = txtOldPass.Text;
            if (pass == "")
            {
                pass = user.Password;
            }else if(pass == user.Password)
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
            string url = user.UrlImagen;
            if (inpImage.PostedFile.FileName != "")
            {
                string imagePath = Server.MapPath("./Images/");
                inpImage.PostedFile.SaveAs(imagePath + "profile-" + user.Id + ".jpg");
                user.UrlImagen = "profile-" + user.Id + ".jpg";
            }
            UserClass aux = new UserClass(user.Email, pass, false);
            aux.UserName = user.UserName;
            aux.UrlImagen = url;
            aux.Id = user.Id;
            negocio.modify(aux);
            Response.Redirect("Default.aspx",false);
        }
    }
}