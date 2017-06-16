<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs"
    Inherits="TTA.Presentation.CreateProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>updateproduct</title>
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
                <legend>Create Product</legend>
                <br />
                <font  size="4px">Product Name:</font>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="txt"></asp:TextBox>
                <br />
                <br />
                <font  size="4px">Product Price :</font>
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="txt"></asp:TextBox>
                <br />
                <br />
                <font  size="4px">Product Category</font>
                <asp:DropDownList ID="ddlCategorylist" runat="server" DataSourceID="odsGetCategory"
                    DataTextField="CategoryName" DataValueField="CategoryId">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsGetCategory" runat="server" SelectMethod="SelectAllCategory"
                    TypeName="TTA.ServiceProxy.Proxy"></asp:ObjectDataSource>
                <br />
                <br />
                <asp:Button ID="btnCreatNew" runat="server" Text="Create New" OnClientClick='return checkvalue()'
                    OnClick="btnCreatNew_Click" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
            </fieldset>
        </div>
        </form>
    </div>
</body>
</html>
<script type="text/javascript">
    function checkvalue() {
        var productname = document.getElementById("txtProductName");
        var productprice = document.getElementById("txtProductPrice");
        if (productname.value == "") {
            alert("please input productname!");
            productname.focus();
            return false;
        } else if (productprice.value == "") {
            alert("please input productprice!");
            productprice.focus();
            return false;
        }
        if (isNaN(productprice.value)) {
            alert("please input number in ProductPrice!");
            productprice.focus();
            return false;
        }
    }
</script>
