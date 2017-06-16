<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="TTA.Presentation.ProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>productlist</title>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/letter.css" />
    <link rel="stylesheet" type="text/css" href="Styles/jqueryform.css" />
</head>
<body>
    <div id="navcontainer">
        <ul id="navlist">
            <li><a href="Index.aspx" target="_blank" id="current">Index</a></li>
            <li><a href="CustomerList.aspx">CustomerList</a></li>
            <li><a href="ProductList.aspx">ProductList</a></li>
            <li><a href="OrderList.aspx">OrderList</a></li>
            <li><a href="CreateOrderDetails.aspx">CreateOrderDetails</a></li>
            <li><a href="SearchOrder.aspx">SearchOrder</a></li>
        </ul>
    </div>
    <div class="exlist">
        <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Product List</legend>
                <asp:Button ID="btnCreateNew" runat="server" Text="Create New" OnClick="btnCreateNew_Click"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                <br />
                <asp:Repeater ID="rptProductList" runat="server" 
                    DataSourceID="odsSelectProduct" OnItemCommand="rptProductList_ItemCommand">
                    <HeaderTemplate>
                        <table class="ui-widget ui-widget-content" width="100%" border="0">
                            <thead>
                                <tr class="ui-widget-header ">
                                    <td>
                                        <b>ProductID</b>
                                    </td>
                                    <td>
                                        <b>ProductName</b>
                                    </td>
                                    <td>
                                        <b>ProductPrice</b>
                                    </td>
                                    <td>
                                        <b>Category</b>
                                    </td>
                                    <td>
                                        <b>option</b>
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td>
                                    <%# Eval("ProductId") %>
                                </td>
                                <td>
                                    <%# Eval("ProductName") %>
                                </td>
                                <td>
                                    <%# Eval("ProductPrice") %>
                                </td>
                                <td>
                                    <%# Eval("Category.CategoryName") %>
                                </td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="btnUpdate" CommandArgument='<%#Eval("ProductId")%>'
                                        CssClass="btn" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="btnDelete" CommandArgument='<%#Eval("ProductId")%>'
                                        OnClientClick='return confirm("delete?")' CssClass="btn" />
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource ID="odsSelectProduct" runat="server" 
                    SelectMethod="SelectAllProduct" TypeName="TTA.ServiceProxy.Proxy">
                </asp:ObjectDataSource>
            </fieldset>
        </div>
        </form>
    </div>
</body>
</html>
