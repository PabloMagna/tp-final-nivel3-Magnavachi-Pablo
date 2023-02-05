<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PreviewImage() {
            var preview = document.getElementById("imgNewImage");
            var file = document.getElementById("fupImage").files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
    <style>
        .btn-purple {
            background-color: #9b59b6;
            color: #fff;
        }


        .rounded-bg {
            background-color: white;
            border-radius: 10px;
            padding: 3%;
            margin-top: 2%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rounded-bg">
        <asp:Label ID="Label1" runat="server" Text="Register" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <div class="row" style="align-content: center">
            <div class="col-md-3">
                <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblWarningEmail" visible="false" runat="server" ForeColor="Red" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="lblWarningPass" Visible="false" runat="server" ForeColor="Red" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label id="lblWarningConfirm" Visible="false" runat="server" ForeColor="Red" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="Label7" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="align-content: center">
            <div class="col-md-3">
                <asp:Label ID="Label2" runat="server" Text="Surname"></asp:Label>
                <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label6" runat="server" Text="Profile Image"></asp:Label>
                <asp:FileUpload ID="fupImage" ClientIDMode="Static" runat="server" CssClass="form-control" onchange="PreviewImage()" />
                <asp:Image ID="imgNewImage" ClientIDMode="Static" runat="server" CssClass="img-fluid m-3" Width="200" Height="200" onerror="this.src='/images/noimage.jpg'" />
            </div>
        </div>
        <br />
        <asp:Button CssClass="btn btn-primary btn-purple" ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="Register" />
    </div>
</asp:Content>
