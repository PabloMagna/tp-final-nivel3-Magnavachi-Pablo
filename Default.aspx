<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProyect_MaxiPrograma_LVL3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-primary:hover {
            background-color: #5c3fc9 !important;
        }

        .bg-purple-light {
            background-color: #5c3fc9 !important;
        }
    </style>
    <script>
        function runScript(e) {
            if (e.keyCode == 13) {
                document.getElementById("btnSearch").click();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <br />
    <asp:UpdatePanel runat="server" onkeypress="return runScript(event)">
        <ContentTemplate>
            <div class="row align-items-center justify-content-between">
                <div class="col-3">
                    <asp:Label ID="lblField" runat="server" ForeColor="white" Text="Main Field"></asp:Label>
                    <asp:DropDownList ID="ddlField" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true" CssClass="btn btn-secondary btn-sm dropdown-toggle bg-purple-light" runat="server">
                        <asp:ListItem Text="Code" />
                        <asp:ListItem Text="Name" />
                        <asp:ListItem Text="Description" />
                        <asp:ListItem Text="Price" />
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label ID="lblcriterion" runat="server" ForeColor="white" Text="Criterion"></asp:Label>
                    <asp:DropDownList ID="ddlCriterion" CssClass="btn btn-secondary btn-sm dropdown-toggle bg-purple-light" runat="server"></asp:DropDownList>
                </div>
                <div class="col-3 d-flex align-items-center">
                    <asp:Label ID="lblFilter" runat="server" Text="Filter: " ForeColor="white" class="d-block"></asp:Label>
                    <asp:TextBox ID="txtFilter" CssClass="form-control ml-2" runat="server"></asp:TextBox>
                </div>
                <div class="col-3 ">
                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary"  BackColor="Purple" runat="server" Text="Search" />
                </div>
            </div>
            <br />
            <asp:GridView CssClass="table table-striped table-dark" ID="dgvList" runat="server"
                AllowPaging="true" PageSize="7" OnPageIndexChanging="dgvList_PageIndexChanging"
                OnSelectedIndexChanged="dgvList_SelectedIndexChanged" DataKeyNames="Id"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" />
                    <asp:BoundField DataField="ItemCode" HeaderText="Code" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:F2}" />
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
