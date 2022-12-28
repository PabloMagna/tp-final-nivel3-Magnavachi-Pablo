using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (Session["ItemList"] == null)
            {
                ItemNegocio negocio = new ItemNegocio();
                Session.Add("ItemList", negocio.toListWithProcedure());
            }

            dgvList.DataSource = Session["ItemList"];
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