<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.MyProfile" %>

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
    <div class="profile-container">
        <div class="row">
            <div class="col-6">
                <div class="form-group">
                    <label>Actual Password</label>
                    <asp:TextBox ID="txtOldPass" Type="password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>New Password</label>
                    <asp:TextBox ID="txtPassword" Type="password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Confirm New Password</label>
                    <asp:TextBox ID="txtConfirmPassword" Type="password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Name</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <label>Surname</label>
                    <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>
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
                            <asp:FileUpload ID="fupImage" ClientIDMode="Static" runat="server" CssClass="form-control" onchange="PreviewImage()" />
                            <div class="text-center">
                                <asp:Label ID="lblNewImage" runat="server" Text="New Image"></asp:Label>
                            </div>
                            <div class="text-center">
                                <asp:Image ID="imgNewImage" ClientIDMode="Static" runat="server" CssClass="img-fluid m-3" Width="200" Height="200" onerror="this.src='/images/noimage.jpg'" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

