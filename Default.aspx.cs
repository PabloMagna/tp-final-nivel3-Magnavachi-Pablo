using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Configuration;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using FinalProyect_MaxiPrograma_LVL3.negocio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class Default : System.Web.UI.Page
    {
        bool shouldFireOtherEvent = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemNegocio negocio = new ItemNegocio();
            if (Session["ItemList"] == null)
            {
                Session.Add("ItemList", negocio.toListWithProcedure());
            }
            //temporal = (List<Items>)Session["ItemList"];
            List<Items> temporal = negocio.toListWithProcedure();
            dgvList.DataSource = temporal;
            dgvList.DataBind();
            if (Session["User"] == null)
            {
                dgvList.Columns[8].Visible = false;
            }
            else if (((UserClass)Session["User"]).TypeUser != typeUser.Admin)
            {
                dgvList.Columns[8].Visible = false;
            }
            if (!IsPostBack)
            {
                ddlCriterion.Items.Clear();
                ddlCriterion.Items.Add("Contains:");
                ddlCriterion.Items.Add("Begins with:");
                ddlCriterion.Items.Add("Ends with:");
            }

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
        protected void dgvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShoppingKart")
            {
                shouldFireOtherEvent = false;

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                dgvList.SelectRow(rowIndex);

                int id = Convert.ToInt32(dgvList.SelectedDataKey.Value.ToString());
                ShoppKartNegocio negocio = new ShoppKartNegocio();

                ShoppKart kart = new ShoppKart(((UserClass)Session["User"]).Id, id, 1);
                negocio.add(kart);
                Response.Redirect("MyProfile.aspx");
                shouldFireOtherEvent = true;
            }
        }
        protected void dgvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shouldFireOtherEvent)
            {
                string id = dgvList.SelectedDataKey.Value.ToString();
                Response.Redirect("addItem.aspx?id=" + id);

            }
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlField.SelectedItem.ToString() == "Price")
            {
                ddlCriterion.Items.Clear();
                ddlCriterion.Items.Add("Iqual to:");
                ddlCriterion.Items.Add("Greater than:");
                ddlCriterion.Items.Add("Less than:");
            }
            else
            {
                ddlCriterion.Items.Clear();
                ddlCriterion.Items.Add("Contains:");
                ddlCriterion.Items.Add("Begins with:");
                ddlCriterion.Items.Add("Ends with:");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ItemNegocio negocio = new ItemNegocio();
            List<Items> temporal = negocio.filtrate(ddlField.SelectedItem.ToString(), ddlCriterion.SelectedItem.ToString(), txtFilter.Text.ToLower());
            dgvList.DataSource = temporal;
            dgvList.DataBind();

        }

    }
}