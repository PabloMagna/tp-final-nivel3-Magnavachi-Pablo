using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class MyFavourites : System.Web.UI.Page
    {
        public List<Items> listaItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUser = ((UserClass)Session["User"]).Id;
            ItemNegocio negocioItem = new ItemNegocio();
            listaItems = negocioItem.getItems(idUser);
            if (listaItems==null)
            {
                lblError.Text = "There's no items in your favourites list";
            }
        }
    }
}