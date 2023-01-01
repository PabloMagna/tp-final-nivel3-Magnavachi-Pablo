<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Register"></asp:Label>
    <br />
    <br />
    <div class="col-md-3">
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:Label ID="Label7" runat="server" Text="Name and Surname"></asp:Label>
        <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-4">
        <asp:Label ID="Label6" runat="server" Text="Profile Image"></asp:Label>
        <input type="file" id="inpImage" class="form-control" runat="server" />
        <asp:Image ID="imgNewProfile" runat="server" CssClass="img-fluid m-3" ImageUrl="https://scontent.fros2-2.fna.fbcdn.net/v/t39.30808-6/299496979_392694929674442_7788072794608832704_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=HxCpmzc8XCcAX86wokR&_nc_ht=scontent.fros2-2.fna&oh=00_AfB6fXHgSoBO0_FX4AhJHiIFDVM9FU7dZpaV882Uyuhm3A&oe=63B794BB"
        />
    </div>

    <br />
    <asp:Button CssClass="btn btn-primary" ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="Register" />
</asp:Content>
