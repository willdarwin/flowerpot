<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateOrderDetails.aspx.cs" Inherits="TTA.Presentation.UpdateOrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel3" runat="server" GroupingText="Order Details" 
            style="text-align: left; margin-left: 0px" Width="100%">
                    <br />
                    <asp:GridView ID="GridViewOrderDetails" runat="server" AutoGenerateColumns="False" 
                onrowcancelingedit="GridViewOrderDetails_RowCancelingEdit" DataKeyNames="OrderDetailId"
                onrowdeleting="GridViewOrderDetails_RowDeleting" onrowediting="GridViewOrderDetails_RowEditing" 
                onrowupdating="GridViewOrderDetails_RowUpdating" style="margin-left: 0px; text-align: center;" 
                        onrowdatabound="GridViewOrderDetails_RowDataBound" AllowPaging="True" 
                        onpageindexchanging="GridViewOrderDetails_PageIndexChanging" Width="100%" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="OrderDetailsId">
                                <ItemTemplate>
                                    <asp:Label ID="OrderDetailId" runat="server" Text='<%#Eval("OrderDetailId")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="OrderDetailId" runat="server" ReadOnly="True" 
                                        Text='<%#Eval("OrderDetailId")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OrderId">
                                <ItemTemplate>
                                    <%#Eval("OrderId")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="OrderId" runat="server" ReadOnly="True" 
                                        Text='<%#Eval("OrderId")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProductName">
                                <ItemTemplate>
                                    <%#Eval("Product.ProductName")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="HFProduct" runat="server" 
                                        Value='<%#Bind("Product.ProductName")%>' />
                                    <asp:DropDownList ID="ProductName" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ProductName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <%#Eval("Quantity")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="Quantity" runat="server" AutoPostBack="True" 
                                        onkeypress="if(event.keyCode&lt;48 ||event.keyCode&gt;57) event.returnValue=false;" 
                                        ontextchanged="Quantity_TextChanged" Text='<%#Eval("Quantity")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TotalPrice">
                                <ItemTemplate>
                                    <%#Eval("TotalPrice")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TotalPrice" runat="server" ReadOnly="true" 
                                        Text='<%#Eval("TotalPrice")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" 
                                        CommandArgument='<%#Eval("OrderDetailId")%>' CommandName="Delete" 
                                        OnClientClick="return confirm('confirm delete or not?')" Text="Delete"></asp:LinkButton>
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
        <asp:HyperLink ID="HyperLink" runat="server" ForeColor="Blue" NavigateUrl="~/OrderList.aspx" >Go to OrderList</asp:HyperLink>
    </p>
    </div>        
    </form>
    
</body>
</html>
