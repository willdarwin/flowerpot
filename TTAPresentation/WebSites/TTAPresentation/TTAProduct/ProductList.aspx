<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="TTAPresentation.TTAProduct.Views.ProductList"
    Title="ProductList" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Show All Products</h1>
    <div class="floatright">
        <input type="button" id="CreateNew" name="CreateNew" onclick="location.href='CreateProduct.aspx'"
            value="Create Product" />
    </div>
    <div class="middle">
        <asp:Panel ID="panelProductList" runat="server" GroupingText="ProductList" HorizontalAlign="Center">
            <asp:Repeater ID="rptProductList" runat="server" OnItemCommand="rptProductList_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" cellspacing="0">
                        <thead>
                            <tr class="head">
                                <td>
                                    <b>Product ID</b>
                                </td>
                                <td>
                                    <b>Product Name</b>
                                </td>
                                <td>
                                    <b>Product Price</b>
                                </td>
                                <td>
                                    <b>Product Category</b>
                                </td>
                                <td>
                                    <b>Operations</b>
                                </td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr class="low">
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
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="btnUpdate" CommandArgument='<%#Eval("ProductId")%>' />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="btnDelete" CommandArgument='<%#Eval("ProductId")%>'
                                    OnClientClick='return confirm("delete?")' />
                            </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tbody>
                        <tr class="alt">
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
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="btnUpdate" CommandArgument='<%#Eval("ProductId")%>' />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="btnDelete" CommandArgument='<%#Eval("ProductId")%>'
                                    OnClientClick='return confirm("delete?")' />
                            </td>
                        </tr>
                    </tbody>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
    </div>
</asp:Content>
