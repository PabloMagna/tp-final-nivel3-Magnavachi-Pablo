using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Data;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using System.Text.RegularExpressions;

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
                UserFavoritesNegocio negocio = new UserFavoritesNegocio();
                if ((Request.QueryString["Id"]) != null && negocio.exists(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"])))
                {
                    ImageButton.ImageUrl = "~/Images/heartFull.png";
                }
                else
                {
                    ImageButton.ImageUrl = "~/Images/heartEmpty.png";
                }
                if ((Request.QueryString["Id"]) == null)
                {
                    ImageButton.Visible = false;
                }
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
            string pattern = "[A-Z]{1}[0-9]{2}";
            decimal number;
            bool isValidNumber = decimal.TryParse(txtPrice.Text, out number);
            try
            {
                if (!Regex.IsMatch(txtCode.Text, pattern))
                {
                    lblCodeWarning.Visible = true;
                    lblCodeWarning.Text = "The code must be in the format A00";
                }
                else if (txtName.Text == "")
                {
                    lblCodeWarning.Visible = false;
                    lblNameWarning.Visible = true;
                    lblNameWarning.Text = "The name can't be empty";
                }
                else if (!isValidNumber || (txtPrice.Text).Length > 10 || number < 0 || txtPrice.Text == "")
                {
                    lblNameWarning.Visible = false;
                    lblPriceWarning.Visible = true;
                    lblPriceWarning.Text = "Please enter a valid number with maximum of 10 digits and two decimal places";
                }
                else
                {
                    Items item = new Items();
                    ItemNegocio negocio = new ItemNegocio();
                    item.Name = txtName.Text;
                    item.ItemCode = txtCode.Text;
                    item.Price = decimal.Parse(txtPrice.Text);
                    if (txtItemDescription.Text != "")
                        item.Description = txtItemDescription.Text;
                    else
                        item.Description = "(not description provided)";
                    if (txtUrlImage.Text != "")
                        item.UrlImage = txtUrlImage.Text;
                    else
                        item.UrlImage = "";
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
                        Items aux = temporal.Find(x => x.Id == int.Parse(Request.QueryString["Id"]));
                        aux = item;
                        negocio.modify(aux, int.Parse(Request.QueryString["Id"]));
                    }
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void txtUrlImage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            UserFavoritesNegocio negocio = new UserFavoritesNegocio();
            if (ImageButton.ImageUrl == "~/Images/heartEmpty.png")
            {
                negocio.add(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
                ImageButton.ImageUrl = "~/Images/heartFull.png";
            }
            else
            {
                negocio.delete(((UserClass)Session["User"]).Id, int.Parse(Request.QueryString["Id"]));
                ImageButton.ImageUrl = "~/Images/heartEmpty.png";
            }
        }
    }
}