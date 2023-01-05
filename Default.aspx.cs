using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                ItemNegocio negocio = new ItemNegocio();
            if (Session["ItemList"] == null)
            {
                Session.Add("ItemList", negocio.toListWithProcedure());
            }
             //temporal = (List<Items>)Session["ItemList"];
            List<Items>temporal =  negocio.toListWithProcedure();
            dgvList.DataSource = temporal;
            dgvList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addItem.aspx");
        }

        protected void dgvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvList.PageIndex = e.NewPageIndex;
            dgvList.DataBind();
        }

        protected void dgvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvList.SelectedDataKey.Value.ToString();
            Response.Redirect("addItem.aspx?id=" + id);
        }
    }
}