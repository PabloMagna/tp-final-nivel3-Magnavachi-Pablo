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
                dgvList.Columns[8].HeaderText = "Add favorites";
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
        // agregar al carrito y mostrar label de agregado
       

        //protected void dgvList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "ShoppingKart")
        //    {
        //        shouldFireOtherEvent = false;

        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        dgvList.SelectRow(rowIndex);

        //        int id = Convert.ToInt32(dgvList.SelectedDataKey.Value.ToString());
        //        ShoppKartNegocio negocio = new ShoppKartNegocio();

        //        ShoppKart kart = new ShoppKart(((UserClass)Session["User"]).Id, id, 1);
        //        negocio.add(kart);

        //        // Obtener el índice de la fila
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        // Obtener la fila y la celda que contiene el botón
        //        GridViewRow row = dgvList.Rows[index];
        //        TableCell cell = row.Cells[9];
        //        // Obtener la referencia al botón
        //        Button button = (Button)cell.Controls[0];
        //        // Crear la etiqueta y agregarla debajo del botón
        //        System.Web.UI.WebControls.Label label = new System.Web.UI.WebControls.Label();
        //        label.Text = "1 item added";
        //        label.ID = "label1"; // Asignar un ID a la etiqueta para poder referenciarla más tarde
        //        cell.Controls.Add(label);

        //        shouldFireOtherEvent = true;
        //    }
        //}

        protected void dgvList_SelectedIndexChanged(object sender, EventArgs e)
        {
                string id = dgvList.SelectedDataKey.Value.ToString();
            if (shouldFireOtherEvent && ((UserClass)Session["User"]).TypeUser == typeUser.Admin)
            {
                Response.Redirect("addItem.aspx?id=" + id);

            }else if(shouldFireOtherEvent && ((UserClass)Session["User"]).TypeUser != typeUser.Admin)
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