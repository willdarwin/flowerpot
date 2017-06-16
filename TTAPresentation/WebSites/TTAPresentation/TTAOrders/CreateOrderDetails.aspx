
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateOrderDetails.aspx.cs" Inherits="TTAPresentation.TTAOrders.Views.CreateOrderDetails"
    Title="CreateOrderDetails" MasterPageFile="~/Shared/DefaultMaster.master" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
        <link rel="stylesheet" href="../Styles/jquery-ui.css" />
        <h1>Create Order Details</h1>
        <div> 
        <asp:Panel ID="Panel1" runat="server" GroupingText="Order" 
            style="text-align: center">
            <div class="left2">
            <asp:Label ID="CustomerLabel" runat="server" Text="Customer"></asp:Label>
            </div>
            <div class="left2">
            <asp:DropDownList ID="DdlCustomer" runat="server" AppendDataBoundItems="True">
                <asp:ListItem>Please Select!</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div>
            <br/>
            <br/>
            <div class="floatright">
                    <asp:Button ID="BtnCreateNewRow" runat="server" Text="Create Order Details"
                    onclick="BtnCreateNewRow_Click" OnClientClick="javascript: return Validate(this)" />
                    <script type="text/javascript">
                        function Validate(CustomerList) {
                            var isSelected = true;
                            if (document.getElementById("<%=DdlCustomer.ClientID%>").value == "Please Select!") {
                                alert("Customer must select first!");
                                isSelected = false
                            }
                            return isSelected;
                        }
                    </script>  
                </div>
            </div>
            </asp:Panel> 
            <asp:Panel ID="Panel2" runat="server" 
                style="text-align: left; margin-left: 81px" Width="80%">      
                <br />
                <asp:GridView ID="GridViewOrderDetails" runat="server" DataKeyNames="OrderDetailId"
                    AutoGenerateColumns="False" 
                    onrowdeleting="GridViewOrderDetails_RowDeleting"  
                    onrowdatabound="GridViewOrderDetails_RowDataBound" Width="100%" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    style="text-align: center; margin-left: 0px;">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>                      
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="HFOrderDetailId" runat="server" EnableViewState="true" Value='<%#Bind("OrderDetailId")%>'/>
                                <asp:HiddenField ID="HFProduct" runat="server" Value='<%#Eval("Product.ProductName")%>'/>
                                <asp:DropDownList ID="DdlProductName" runat="server" AutoPostBack="True"
                                    onselectedindexchanged="DdlProductName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="TxbQuantity" runat="server" Text='<%#Eval("Quantity")%>'
                                onkeypress="if(event.keyCode<48 ||event.keyCode>57) event.returnValue=false;" 
                                    AutoPostBack="True" ontextchanged="TxbQuantity_TextChanged">0</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                <asp:TextBox ID="TxbTotalPrice" runat="server" ReadOnly="True" Text='<%#Eval("TotalPrice")%>'>0</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="BtnDelete" runat="server" CausesValidation="false" 
                                    CommandName="Delete" Text="Delete" OnClientClick="return confirm('confirm delete or not?')"/>
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
            </asp:Panel>      
            <div class="floatright">
                <br/>
                <asp:Button ID="BtnSave" runat="server" Text="Save Order" onclick="BtnSave_Click" Enabled="False" />
            </div>    
    </div>
</asp:Content>
