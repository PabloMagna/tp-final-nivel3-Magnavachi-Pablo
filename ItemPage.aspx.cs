using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class ItemPage : System.Web.UI.Page
    {
        public Items item { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserFavoritesNegocio negocio = new UserFavoritesNegocio();
                //if (negocio.exists(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"])))
                //{
                //    cbxAddFavorites.Checked = true;
                //}
                //else
                //{
                //    cbxAddFavorites.Checked = false;
                //}
                if (negocio.exists(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"])))
                {
                    ImageButton.ImageUrl = "~/Images/heartFull.png";
                }
                else
                {
                    ImageButton.ImageUrl = "~/Images/heartEmpty.png";
                }
            }
            if (Request.QueryString["Id"] != null)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                List<Items> temporal = (List<Items>)Session["ItemList"];
                item = temporal.Find(x => x.Id == id);
                Page.DataBind();
            }
        }

        //protected void cbxAddFavorites_CheckedChanged(object sender, EventArgs e)
        //{
        //    UserFavoritesNegocio negocio = new UserFavoritesNegocio();
        //    if (cbxAddFavorites.Checked)
        //    {
        //        negocio.add(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
        //    }
        //    else
        //    {
        //        negocio.delete(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
        //    }
        //}

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            UserFavoritesNegocio negocio = new UserFavoritesNegocio();
            if (ImageButton.ImageUrl == "~/Images/heartEmpty.png")
            {
                ImageButton.ImageUrl = "~/Images/heartFull.png";
                negocio.add(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
            }
            else
            {
                ImageButton.ImageUrl = "~/Images/heartEmpty.png";
                negocio.delete(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
            }
        }
    }

}