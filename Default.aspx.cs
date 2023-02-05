using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
                dgvList.Columns[8].Visible = true;
                dgvList.HeaderRow.Cells[8].Text = "Add Favorites"; 
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

        protected void dgvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvList.SelectedDataKey.Value.ToString();
            if (shouldFireOtherEvent && ((UserClass)Session["User"]).TypeUser == typeUser.Admin)
            {
                Response.Redirect("addItem.aspx?id=" + id);

            }
            else if (shouldFireOtherEvent && ((UserClass)Session["User"]).TypeUser != typeUser.Admin)
            {
                Response.Redirect("itemPage.aspx?id=" + id);
            }
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlField.SelectedItem.ToString() == "Price")
            {
                ddlCriterion.Items.Clear();
                ddlCriterion.Items.Add("Equal to:");
                ddlCriterion.Items.Add("Greater than:");
                ddlCriterion.Items.Add("Lower than:");
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
            lblSearchWarning.Visible = false;
            string input = txtFilter.Text;
            if (input.Contains(",") && ddlField.SelectedItem.ToString() == "Price")
            {
                lblSearchWarning.Visible = true;
                lblSearchWarning.Text = "Please, do not use ','; use '.' instead";
            }
            else
            {
                decimal number;
                bool isValidNumber = decimal.TryParse(input, out number);
                if (ddlField.SelectedItem.ToString() == "Price" && (!isValidNumber || input.Length > 10 || number < 0))
                {
                    lblSearchWarning.Visible = true;
                    lblSearchWarning.Text = "Please, enter a number (0.00)";
                }
                else
                {
                    ItemNegocio negocio = new ItemNegocio();
                    List<Items> temporal = negocio.filtrate(ddlField.SelectedItem.ToString(), ddlCriterion.SelectedItem.ToString(), txtFilter.Text.ToLower());
                    dgvList.DataSource = temporal;
                    dgvList.DataBind();
                }
            }
        }
    }
}