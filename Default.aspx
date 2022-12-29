<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table table-striped table-dark" ID="dgvList" runat="server"
        AllowPaging="true" PageSize="3" OnPageIndexChanging="dgvList_PageIndexChanging" 
        OnSelectedIndexChanged="dgvList_SelectedIndexChanged" DataKeyNames="Id"
        AutoGenerateColumns="false">
        <columns>
            <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" />
            <asp:BoundField DataField="ItemCode" HeaderText="Code" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="UrlImage" Visible="false" HeaderText="Image" />
            <asp:BoundField DataField="TradeDesciption" HeaderText="Trademark" />
            <asp:boundField DataField="CategoryDescription" HeaderText ="Category" />
            <asp:CommandField HeaderText="Modify" ShowSelectButton="true" SelectText="✏️" />
            
        </columns>
    </asp:GridView>
    <asp:Button ID="btnAdd" cssClass="btn btn-lg btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click" />
</asp:Content>
