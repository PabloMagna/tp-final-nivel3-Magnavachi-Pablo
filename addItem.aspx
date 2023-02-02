<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mx-auto  bg-white rounded-md"" style="margin:4%">
        <div class="row" style="padding:2%">
            <div class="col-6">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label ID="labelTitle" CssClass="form-label" Font-Size="X-Large" Text="Add Item" runat="server" />

                    </div>
                    <div class="mb-3">
                        <label for="txtCode" class="form-label">Code</label>
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        <asp:Label id="lblCodeWarning" ForeColor="Red" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="txtName" class="form-label">Name</label>
                        <asp:TextBox ID="txtName" MaxLength="50" runat="server"></asp:TextBox>
                        <asp:Label id="lblNameWarning" ForeColor="Red" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="txtPrice" class="form-label">Price</label>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                        <asp:Label id="lblPriceWarning" ForeColor="Red" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label for="txtItemDescription" class="form-label">Item Description</label>
                        <asp:TextBox ID="txtItemDescription" TextMode="MultiLine" MaxLength="150" runat="server"></asp:TextBox>

                    </div>
                    <div class="mb-3">
                        <label for="txtUrlImage" class="form-label">URL Image</label>
                        <asp:TextBox ID="txtUrlImage" MaxLength="1000" AutoPostBack="true" OnTextChanged="txtUrlImage_TextChanged" runat="server"></asp:TextBox>

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
                <div class="card-body">
                    <asp:ImageButton ID="ImageButton" autoposback="true" ImageUrl="~/Images/heartEmpty.png" runat="server" OnClick="ImageButton_Click" Height="20px" Width="20px" />
                </div>
            </div>
            <div class="d-flex align-items-center col-6">
                <img src="<% = txtUrlImage.Text%>" onerror="this.src='Images/default.png'" style="max-width: 300px; max-height: 300px;">
            </div>
        </div>
    </div>

</asp:Content>
