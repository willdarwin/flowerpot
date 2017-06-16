<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateProduct.aspx.cs" Inherits="TTAPresentation.TTAProduct.Views.CreateProduct"
    Title="CreateProduct" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="TTAjs" ContentPlaceHolderID="TTAhead" runat="Server">
    <script type="text/javascript">
        function CheckValue() {
            var productname = document.getElementById("<%=txtProductName.ClientID%>");
            var productprice = document.getElementById("<%=txtProductPrice.ClientID%>");
            if (productname.value == "") {
                document.getElementById("ProductNameMsg").innerText = "Please input ProductName!";
                productname.focus();
                return false;
            }
            else {
                document.getElementById("ProductNameMsg").innerText = "";
            }
            if (productprice.value == "") {
                document.getElementById("ProductPriceMsg").innerText = "Please input number in ProductPrice!";
                productprice.focus();
                return false;
            }
            else {
                document.getElementById("ProductPriceMsg").innerText = "";
            }
            if (isNaN(productprice.value)) {
                document.getElementById("ProductPriceMsg").innerText = "Please input number in ProductPrice!";
                productprice.focus();
                return false;
            }
            else {
                document.getElementById("ProductPriceMsg").innerText = "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="TTAbody" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Create Product</h1>
    <asp:Panel ID="panelCreateProduct" runat="server" GroupingText="CreateProduct">
        <div class="left2">
            Product Name
        </div>
        <div class="middle2">
            <asp:TextBox ID="txtProductName" runat="server" CssClass="txt"></asp:TextBox>
        </div>
        <div class="right2">
            <span id="ProductNameMsg" class="ErrorSpan"></span>
        </div>
        <div class="left2">
            Product Price
        </div>
        <div class="middle2">
            <asp:TextBox ID="txtProductPrice" runat="server" CssClass="txt" onkeyup="if(isNaN(value))execCommand('undo')"
                onafterpaste="if(isNaN(value))execCommand('undo')"></asp:TextBox>
        </div>
        <div class="right2">
            <span id="ProductPriceMsg" class="ErrorSpan"></span>
        </div>
        <div class="left2">
            Product Category
        </div>
        <div class="middle2">
            <asp:DropDownList ID="ddlCategorylist" runat="server" AppendDataBoundItems="True"
                DataTextField="CategoryName" DataValueField="CategoryId">
            </asp:DropDownList>
        </div>
        <div class="right2">
            <asp:Button ID="btnCreatNew" runat="server" Text="Save" OnClientClick='return CheckValue()'
                OnClick="btnCreatNew_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </asp:Panel>
</asp:Content>
