<%@ Page Language="C#" CodeBehind="CreateOrderDetails.aspx.cs" Inherits="TTA.Presentation.CreateOrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="Order" 
            style="text-align: center">
            <asp:Label ID="CustomerLabel" runat="server" Text="Customer"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="CustomerList" runat="server" 
    AppendDataBoundItems="True">
                <asp:ListItem>Please Select!</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" 
                style="text-align: left; margin-left: 81px" Width="80%">
                <asp:Button ID="CreateNewRow" runat="server" Text="Create Order Details"
                    onclick="CreateNewRow_Click" OnClientClick="CreateNewRow_Click()" />
                    <script type="text/javascript">
                        function CreateNewRow_Click() {
                            if (document.getElementById("CustomerList").value =="Please Select!") {
                                alert("Customer must select first!");
                            }
                            return false;
                        }
                    </script>             
                <br />
                <br />
                <asp:GridView ID="GridViewOrderdetails" runat="server" DataKeyNames="OrderDetailId"
                    AutoGenerateColumns="False" 
                    onrowdeleting="GridViewOrderdetails_RowDeleting"  
                    onrowdatabound="GridViewOrderdetails_RowDataBound" Width="100%">
                    <Columns>                      
                        <asp:TemplateField HeaderText="ProductName">
                            <ItemTemplate>
                                <asp:HiddenField ID="OrderDetailId" runat="server" EnableViewState="true" Value='<%#Bind("OrderDetailId")%>'/>
                                <asp:HiddenField ID="HFProduct" runat="server" Value='<%#Eval("Product.ProductName")%>'/>
                                <asp:DropDownList ID="ProductNameList" runat="server" AutoPostBack="True"
                                    onselectedindexchanged="ProductNameList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="Quantity" runat="server" Text='<%#Eval("Quantity")%>'
                                onkeypress="if(event.keyCode<48 ||event.keyCode>57) event.returnValue=false;" 
                                    AutoPostBack="True" ontextchanged="Quantity_TextChanged">0</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TotalPrice">
                            <ItemTemplate>
                                <asp:TextBox ID="TotalPrice" runat="server" ReadOnly="True" Text='<%#Eval("TotalPrice")%>'>0</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete" OnClientClick="return confirm('confirm delete or not?')" >
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="Save" runat="server" Text="Save" onclick="Save_Click" />
            </asp:Panel>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
