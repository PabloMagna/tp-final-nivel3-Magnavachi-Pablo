using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Data;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrademarkNegocio trade = new TrademarkNegocio();
            CategoryNegocio category = new CategoryNegocio();
            if (!IsPostBack)
            {
                ddlTradeDescription.DataSource = trade.listar();
                ddlTradeDescription.DataTextField = "TradeDescription";
                ddlTradeDescription.DataValueField = "TradeId";
                ddlTradeDescription.DataBind();

                ddlCategoryDescription.DataSource = category.listar();
                ddlCategoryDescription.DataTextField = "CategoryDescription";
                ddlCategoryDescription.DataValueField = "CategoryId";
                ddlCategoryDescription.DataBind();


                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    List<Items> temporal = (List<Items>)Session["ItemList"];
                    Items item = temporal.Find(x => x.Id == id);

                    labelTitle.Text = "Modify Item";
                    txtCode.Text = item.ItemCode;
                    txtItemDescription.Text = item.Description;
                    txtPrice.Text = item.Price.ToString();
                    txtUrlImage.Text = item.UrlImage;
                    txtName.Text = item.Name;
                    ddlTradeDescription.SelectedValue = item.TradeDesciption.ToString();
                    ddlCategoryDescription.SelectedValue = item.CategoryDescription.ToString();
                    btnAdd.Text = "Modify";
                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Items item = new Items();
            ItemNegocio negocio = new ItemNegocio();
            item.Name = txtName.Text;
            item.ItemCode = txtCode.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Description = txtItemDescription.Text;
            item.UrlImage = txtUrlImage.Text;
            Trademarks trade = new Trademarks();
            trade.TradeId = int.Parse(ddlTradeDescription.SelectedValue);
            trade.TradeDescription = ddlTradeDescription.Text;
            item.TradeDesciption = trade;
            Category cate = new Category();
            cate.CategoryId = int.Parse(ddlTradeDescription.SelectedValue);
            cate.CategoryDescription = ddlCategoryDescription.Text;
            item.CategoryDescription = cate;

            List<Items> temporal = (List<Items>)Session["ItemList"];
            if (Request.QueryString["Id"] == null)
            {
                negocio.add(item);
                temporal.Add(item);
            }
            else
            {
                negocio.modify(item, int.Parse(Request.QueryString["Id"]));
                temporal.Remove(temporal.Find(x => x.Id == int.Parse(Request.QueryString["Id"])));
                temporal.Add(item);
                //temporal.Clear();
                //Session.Add("ItemList", negocio.toListWithProcedure());

            }
            Response.Redirect("Default.aspx", false);
        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}