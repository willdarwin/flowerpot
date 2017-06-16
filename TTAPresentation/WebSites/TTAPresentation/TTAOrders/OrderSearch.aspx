<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderSearch.aspx.cs" Inherits="TTAPresentation.TTAOrders.Views.OrderSearch"
    Title="OrderDetails Search" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content1" ContentPlaceHolderID="TTAhead" runat="Server">
    <link rel="stylesheet" href="../Styles/jquery-ui.css" />
    <script type="text/javascript" src="../Js/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=tbxStartDate.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
            $("#<%=tbxEndDate.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Search Order Details </h1>
    <center>
        <asp:Panel ID="panelSearchConditions" CssClass="searchpanel" runat="server" GroupingText="SearchConditions"
            Height="100px" HorizontalAlign="Center">
            <div class="left">
                <span>CustomerName</span>
                <asp:TextBox ID="tbxCustomerName" runat="server"></asp:TextBox>
            </div>
            <div class="right">
                <span>ProductName</span>
                <asp:TextBox ID="tbxProductName" runat="server"></asp:TextBox>
            </div>
            <div class="left">
                <span>OrderDateFrom</span>
                <asp:TextBox ID="tbxStartDate" runat="server"></asp:TextBox>
            </div>
            <div class="right">
                <span>OrderDateTo</span>
                <asp:TextBox ID="tbxEndDate" runat="server"></asp:TextBox>
            </div>
            <div class="floatright">
                <asp:Button ID="btnSearchResult" runat="server" Text="Search" OnClick="btnSearchResult_Click"
                    Width="75px" />
            </div>
        </asp:Panel>
        <asp:Panel ID="panelSearchResult" runat="server" GroupingText="OrderDetails Search Result">
            <asp:GridView ID="GVSearchResults" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" Width="100%" AllowSorting="True"
                OnSorting="GVSorting" AllowPaging="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" 
                        SortExpression="OrderId" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" 
                        SortExpression="CreatedDate" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
                        SortExpression="CustomerName" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" 
                        SortExpression="ProductName" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" 
                        SortExpression="TotalPrice" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:LinkButton ID="btnFirstPage" runat="server" OnClick="btnFirstPage_Click" Enabled="false"><<</asp:LinkButton>
            <asp:LinkButton ID="btnPrePage" runat="server" OnClick="btnPrePage_Click" Enabled="false"><</asp:LinkButton>&nbsp
            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
            <asp:Label ID="lblPageCount" runat="server"></asp:Label>
            <asp:LinkButton ID="btnNextPage" runat="server" OnClick="btnNextPage_Click" Enabled="false">></asp:LinkButton>&nbsp
            <asp:LinkButton ID="btnLastPage" runat="server" OnClick="btnLastPage_Click" Enabled="false">>></asp:LinkButton>
            <asp:Label ID="lblToPage" runat="server" Text="GoTo"></asp:Label>
            <asp:DropDownList ID="ddlPageCount" runat="server" Height="17px" OnTextChanged="ddlPageCount_TextChanged"
                AutoPostBack="true" Width="53px">
            </asp:DropDownList>
        </asp:Panel>
    </center>
</asp:Content>
