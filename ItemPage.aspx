<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.ItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-center">
 <img class="card-img-top" src="<%= item.UrlImage %>" onerror="this.src='Images/default.png'" alt="<%= item.Name %>" style="max-width:200px; max-height:200px; margin:0 auto; display:block;">
  <div class="card-body">
    <h5 class="card-title"><%= item.Name %></h5>
    <p class="card-text"><%= item.Description %></p>
  </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">Precio: <%= item.Price %></li>
    <li class="list-group-item"><%= item.TradeDesciption.TradeDescription %></li>
    <li class="list-group-item"><%= item.CategoryDescription.CategoryDescription %></li>
  </ul>
  <div class="card-body">
      <asp:CheckBox AutoPostBack="true" Text="Add Favorites" ID="cbxAddFavorites" OnCheckedChanged="cbxAddFavorites_CheckedChanged" runat="server" />
  </div>
</div>

</asp:Content>
