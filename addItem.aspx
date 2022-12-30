<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="labelTitle" Text="Add Item" runat="server" />

                </div>
                <div class="mb-3">
                    <label for="txtCode" class="form-label">Code</label>
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>

                </div>
                <div class="mb-3">
                    <label for="txtName" class="form-label">Name</label>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                </div>
                <div class="mb-3">
                    <label for="txtPrice" class="form-label">Price</label>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RangeValidator ErrorMessage="Solo Numeros" ControlToValidate="txtPrice" runat="server" type="Double" Display="Static"/>

                </div>
                <div class="mb-3">
                    <label for="txtItemDescription" class="form-label">Item Description</label>
                    <asp:TextBox ID="txtItemDescription" runat="server"></asp:TextBox>

                </div>

                <div class="mb-3">
                    <label for="txtUrlImage" class="form-label">URL Image</label>
                    <asp:TextBox ID="txtUrlImage" AutoPostBack="true" OnTextChanged="txtUrlImage_TextChanged" runat="server"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>

                </div>
                <div class="mb-3">
                    <label for="txtTradeDescription" class="form-label">Trade Description</label>
                    <asp:DropDownList ID="ddlTradeDescription" runat="server" CssClass="dropdown" />
                </div>
                <div class="mb-3">
                    <label for="txtCategoryDescription" class="form-label">Category Description</label>
                    <asp:DropDownList ID="ddlCategoryDescription" runat="server" CssClass="dropdown" />
                </div>
                <div class="mb-3">
                    <asp:Button CssClass="btn btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

                </div>
            </div>
            <div class="col-6">
                <image src="<% = txtUrlImage.Text%>" />
            </div>
        </div>
    </asp:UpdatePanel>
</asp:Content>
