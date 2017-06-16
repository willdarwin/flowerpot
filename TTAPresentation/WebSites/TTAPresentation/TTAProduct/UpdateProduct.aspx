<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateProduct.aspx.cs" Inherits="TTAPresentation.TTAProduct.Views.UpdateProduct"
    Title="UpdateProduct" MasterPageFile="~/Shared/DefaultMaster.master" %>

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
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Update Product</h1>
    <asp:Panel ID="PanelUpdateProduct" runat="server" GroupingText="UpdateProduct">
        <asp:HiddenField ID="hfldProductId" runat="server" />
        <div class="left2">
            Product Name
        </div>
        <div class="middle2">
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        </div>
        <div class="right2">
            <span id="ProductNameMsg" class="ErrorSpan"></span>
        </div>
        <div class="left2">
            Product Price
        </div>
        <div class="middle2">
            <asp:TextBox ID="txtProductPrice" runat="server" onkeyup="if(isNaN(value))execCommand('undo')"
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
        <div class="left2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick='return CheckValue()'
                OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
        <asp:Label ID="labId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="labMethod" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>
