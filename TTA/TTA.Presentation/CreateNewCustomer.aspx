<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewCustomer.aspx.cs" Inherits="TTA.Presentation.CreateNewCustomer" %>
<%@ Import namespace="TTA.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Customer">

        CustomerName &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txCustomerName" runat="server"></asp:TextBox><br /><br /><br />
        CustomerGender
        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">Male</asp:ListItem>
            <asp:ListItem Value="1">Female</asp:ListItem>
        </asp:RadioButtonList><br /><br />
        &nbsp;CustomerAddress &nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="dropListAddresses" runat="server" 
            AppendDataBoundItems="True">
            <asp:ListItem Value="0">Please Select</asp:ListItem>
        </asp:DropDownList>
        <br /><br /><br />
        <asp:Button ID="btnCreateNewCustomer" runat="server" Text="Create New" 
            onclick="Button1_Click" />
        <asp:Label ID="labId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="labMethod" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
    </form>
</body>
</html>
