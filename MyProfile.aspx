<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.MyProfile" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function uploadImage() {
            var fileUpload = document.getElementById("<%=fupImage.ClientID%>");
            var imgNewProfile = document.getElementById("<%=imgNewProfile.ClientID%>");
            if (fileUpload.value != "") {
                imgNewProfile.src = URL.createObjectURL(fileUpload.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Register"></asp:Label>
    <br />
    <br />
    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="Label5" runat="server" Text="Actual Password"></asp:Label>
            <asp:TextBox ID="txtOldPass" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label4" runat="server" Text="Confirm New Password"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label7" runat="server" Text="Name and Surname"></asp:Label>
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="fupImage" OnLoad="fupImage_Load" runat="server" CssClass="form-control" onchange="this.form.submit();" />
                    <asp:Image ID="imgNewProfile" runat="server" CssClass="img-fluid m-3" Width="100" Height="100" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
    <br />

</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function uploadImage() {
            var fileUpload = document.getElementById("<%=fupImage.ClientID%>");
            var imgNewProfile = document.getElementById("<%=imgNewProfile.ClientID%>");
            if (fileUpload.value != "") {
                imgNewProfile.src = URL.createObjectURL(fileUpload.files[0]);
            }
        }
    </script>
    <style>
        /* Agrega tus estilos aquí */
        .form-control {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border-radius: 10px;
            border: none;
            background-color: #f8f9fa;
        }

        .profile-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
        }

        .profile-form {
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            justify-content: center;
        }

            .profile-form > div {
                width: 100%;
                margin-bottom: 20px;
            }

                .profile-form > div > label {
                    font-size: 14px;
                    font-weight: bold;
                    margin-bottom: 10px;
                }

            .profile-form input[type="text"], .profile-form input[type="password"] {
                width: 100%;
                padding: 12px 20px;
                margin: 8px 0;
                box-sizing: border-box;
                border-radius: 10px;
                border: none;
                background-color: #f8f9fa;
            }

            .profile-form .btn {
                background-color: #7c4dff;
                color: #fff;
                padding: 10px 20px;
                border-radius: 10px;
                cursor: pointer;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Register"></asp:Label>
    <br />
    <br />
    <div class="profile-container">
        <div class="row">
            <div class="col-6">
                <div class="form-group">
                    <label>Actual Password</label>
                    <asp:TextBox ID="txtOldPass" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>New Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Confirm New Password</label>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Name and Surname</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
                <br />
            </div>
            <div class="col-6">
                <div class="form-group">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <br />
                            <asp:FileUpload ID="fupImage" OnLoad="fupImage_Load" runat="server" CssClass="form-control" onchange="this.form.submit();" />
                            <div class="text-center">
                                <asp:Image ID="imgNewProfile" runat="server" CssClass="img-fluid m-3" Width="200" Height="200" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

