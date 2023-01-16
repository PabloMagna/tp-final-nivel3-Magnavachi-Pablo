<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblField" runat="server" Text="Field"></asp:Label>
                        <asp:DropDownList ID="ddlField" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true"
                            CssClass="btn btn-secondary btn-sm dropdown-toggle" runat="server">
                            <asp:ListItem Text="Code" />
                            <asp:ListItem Text="Name" />
                            <asp:ListItem Text="Description" />
                            <asp:ListItem Text="Price" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div>
                        <asp:Label ID="lblcriterion" runat="server" Text="Criterion"></asp:Label>
                        <asp:DropDownList ID="ddlCriterion" CssClass="btn btn-secondary btn-sm dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblFilter" runat="server" Text="Filter"></asp:Label>
                        <asp:TextBox ID="txtFilter" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary" runat="server" Text="Search" />
                        </div>
                    </div>
                    </d
                </div>
                <asp:GridView CssClass="table table-striped table-dark" ID="dgvList" runat="server"
                    AllowPaging="true" PageSize="3" OnPageIndexChanging="dgvList_PageIndexChanging"
                    OnSelectedIndexChanged="dgvList_SelectedIndexChanged" DataKeyNames="Id"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" />
                        <asp:BoundField DataField="ItemCode" HeaderText="Code" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="UrlImage" Visible="false" HeaderText="Image" />
                        <asp:BoundField DataField="TradeDesciption" HeaderText="Trademark" />
                        <asp:BoundField DataField="CategoryDescription" HeaderText="Category" />
                        <asp:CommandField HeaderText="Modify" ShowSelectButton="true" SelectText="✏️" />

                    </Columns>
                </asp:GridView>
                <%if (((FinalProyect_MaxiPrograma_LVL3.dominio.UserClass)Session["User"]).TypeUser == FinalProyect_MaxiPrograma_LVL3.dominio.typeUser.Admin)
                    { %>
                <asp:Button ID="btnAdd" CssClass="btn btn-lg btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click" />
                <%} %>
               <%-- <asp:Button ID="confirmChanges" CssClass="btn btn-lg btn-primary" runat="server" Text="Confirm Changes" OnClick="confirmChanges_Click"/>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
