<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyFavourites.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.MyFavourites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">+
    <br />
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="card text-center">
        <div class="row">
            <% if (listaItems != null)
                {
                    foreach (var item in listaItems)
                    { %>
            <div class="col-sm-4" style="padding:20px">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title"><%= item.Name %></h5>
                        <img src="<%= item.UrlImage %>" class="card-img-top" alt="..." style="max-height: 100px; max-width: 100px; margin: auto" onerror="this.src='Images/default.png'">
                        <p class="card-text"><%= item.Description %></p>
                        <h5>Precio: <%= item.Price.ToString("F2") %> </h5>
                        <p class="card-text">Category: <%=item.CategoryDescription.CategoryDescription%></p>
                        <p class="card-text">TradeMark: <%=item.TradeDesciption.TradeDescription %></p>
                    </div>
                </div>
            </div>
            <% }
                } %>
        </div>
    </div>
</asp:Content>
