
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrderDetails.aspx.cs" Inherits="TTAPresentation.TTAOrders.Views.UpdateOrderDetails"
    Title="UpdateOrderDetails" MasterPageFile="~/Shared/DefaultMaster.master" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
    <h1>Update Order Details</h1>
<script type="text/javascript" src="../Js/jquery-1.4.1.min.js"></script>
<asp:Panel ID="Panel3" runat="server" GroupingText="Order Details" 
    style="text-align: center; margin-left: 0px" Width="100%">
            <asp:GridView ID="GridViewOrderDetails" runat="server" AutoGenerateColumns="False" 
        onrowcancelingedit="GridViewOrderDetails_RowCancelingEdit" DataKeyNames="OrderDetailId"
        onrowdeleting="GridViewOrderDetails_RowDeleting" onrowediting="GridViewOrderDetails_RowEditing" 
        onrowupdating="GridViewOrderDetails_RowUpdating" style="margin-left: 0px" 
        onrowdatabound="GridViewOrderDetails_RowDataBound" AllowPaging="True" 
        onpageindexchanging="GridViewOrderDetails_PageIndexChanging" Width="100%" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Order Detail Id">
                        <ItemTemplate>
                            <asp:Label ID="LblOrderDetailId" runat="server" Text='<%#Eval("OrderDetailId")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxbOrderDetailId" runat="server" ReadOnly="True" 
                                Text='<%#Eval("OrderDetailId")%>' BackColor="#CCCCCC"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Id">
                        <ItemTemplate>
                            <asp:Label ID="LblOrderId" runat="server" Text='<%#Eval("OrderId")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxbOrderId" runat="server" ReadOnly="True" 
                                Text='<%#Eval("OrderId")%>' BackColor="#CCCCCC"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>      
                            <asp:HiddenField ID="HFProductId" runat="server" Value='<%#Bind("Product.ProductId")%>' />                                
                            <asp:Label ID="LblProductName" runat="server" Text='<%#Eval("Product.ProductName")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="HFProduct" runat="server" 
                                Value='<%#Bind("Product.ProductName")%>' />
                            <asp:DropDownList ID="DdlProductName" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DdlProductName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="LblQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxbQuantity" runat="server" AutoPostBack="True" 
                                onkeypress="if(event.keyCode&lt;48 ||event.keyCode&gt;57) event.returnValue=false;" 
                                ontextchanged="Quantity_TextChanged" Text='<%#Eval("Quantity")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <asp:Label ID="LblTotalPrice" runat="server" Text='<%#Eval("TotalPrice")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxbTotalPrice" runat="server" ReadOnly="true" 
                                Text='<%#Eval("TotalPrice")%>' BackColor="#CCCCCC"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:Button ID="BtnUpdate" runat="server" CausesValidation="False" 
                                CommandName="Update" Text="Update" OnClientClick="return Validate(this)"/>
                                <script type="text/javascript">
                                    function Validate(quantity) {
                                        var flag = true; 
                                        var value = $(quantity).parent().prev().prev().find('input').val();
                                        if (value == 0) {
                                            alert('Quantity can not equal zero!')
                                            flag = false;
                                        }
                                        return flag;
                                    }
                                </script>  
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="BtnEdit" runat="server" CausesValidation="false" 
                                CommandName="Edit" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" 
                                CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="BtnDelete" runat="server" CausesValidation="false" 
                                CommandName="Delete" Text="Delete" 
                                OnClientClick="return confirm('confirm delete or not?')"/>
                        </ItemTemplate>
                    </asp:TemplateField>
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
            <br />
        </asp:Panel>
     <p style="text-align: right">
        <asp:HyperLink ID="HyperLink" runat="server" ForeColor="Blue"  NavigateUrl="~/TTAOrders/OrderList.aspx" >Go to OrderList</asp:HyperLink>
    </p>
</asp:Content>
