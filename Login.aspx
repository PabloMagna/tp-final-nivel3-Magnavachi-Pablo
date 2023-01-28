<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Login" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] == null)
        {
    %>
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
        <asp:Button ID="btnLogin" Text="Login" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" />
    </div>
    <%}
        else
        {%>
    <br />
    <asp:Label ID="lblLogued" runat="server">Ya te encuentras logueado </asp:Label>
    <%} %>
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilos para el contenedor principal */
        .login-container {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-wrap: wrap;
        }

        /* Estilos para el formulario de inicio de sesión */
        .login-form {
            text-align: center;
            width: 100%;
            max-width: 300px;
            padding: 15px;
            border-radius: 10px;
            background-color: #f8f9fa;
        }

        /* Estilos para los elementos del formulario */
        .login-form label {
            font-size: 1rem;
        }
        .login-form input[type="email"], .login-form input[type="password"] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border-radius: 10px;
            background-color: white;
            border: 1px solid black;
        }
        /* Estilos para el botón de inicio de sesión */
        .login-form input[type="submit"] {
            width: 100%;
            background-color: #6c5ce7;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            font-size: 1rem;
        }
        .login-form input[type="submit"]:hover {
            background-color: #5c3fc9;
        }
        .logued{
            margin-bottom:10%;
            margin:3%;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] == null)
        {
    %>
    <div class="login-container" style="padding:2%">
    <div class="login-form">
        <label for="inputEmail4">Email</label>
        <asp:TextBox runat="server" type="email" ID="txtEmail"/>
        <br />
        <label for="inputPassword4">Password</label>
        <asp:TextBox runat="server" type="password" ID="txtPassword"/>
        <br />
        <br />
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" CssClass="btn-login" />
    </div>
    <%}
        else
        {%>
    <br />
    <asp:Label CssClass="logued" ID="lblLogued" runat="server"> You are already logued!! </asp:Label>
    <%} %>
    </div>
</asp:Content>

