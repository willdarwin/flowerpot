<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TTA.Presentation.CustomerList" %>
<%@ Import namespace="TTA.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="CustomerList">
            <asp:Button ID="btnCreateNewCustomer" runat="server" Text="Create New Customer" 
                onclick="Button1_Click" /><br />
        
    <asp:Repeater ID="reapterCustomers" runat="server" 
                onitemcommand="Repeater1_ItemCommand" 
                onitemdatabound="reapterCustomers_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td><%#Eval("CustomerId") %></td>
                <td><%#Eval("CustomerName")%></td>
                <td><%# ((CustomerBE)(Container.DataItem)).CustomerGender ? "Female" : "Male"%></td>
                <td><%#Eval("Address")%></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("CustomerId") %>' />
                    <asp:Button ID="Button3" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("CustomerId") %>'/>
                </td>  
            </tr>
        </ItemTemplate>
        <HeaderTemplate><table border="1"><tr><td>CustomerId</td><td>CustomerName</td><td>CustomerGender</td><td>CustomerAddress</td><td>&nbsp;&nbsp;&nbsp;</td></tr></HeaderTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    </asp:Panel>
    </div>
    </form>

</body>
</html>
