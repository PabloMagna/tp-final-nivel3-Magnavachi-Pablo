<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3">
        <label for="inputEmail4" class="form-label">Email</label>
        <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" />
    </div>
    <div class="col-md-3">
        <label for="inputPassword4" class="form-label">Password</label>
        <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPassword" />
    </div>
    <div class="col-12">
        <br />
        <asp:Button ID="btnLogin" Text="Login" cssClass="btn-primary" runat="server" OnClick="btnLogin_Click"/>
    </div>
</asp:Content>
