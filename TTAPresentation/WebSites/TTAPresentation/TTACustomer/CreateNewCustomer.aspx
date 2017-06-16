<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateNewCustomer.aspx.cs"
    Inherits="TTAPresentation.TTACustomer.Views.CreateNewCustomer" Title="CreateNewCustomer"
    MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1><%= _strTitle %></h1>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Customer">
        <div class="left2">
            <span>CustomerName</span>
        </div>
        <div class="middle2">
            <asp:TextBox ID="txCustomerName" runat="server" Width="140px"></asp:TextBox>
        </div>
        <div class="right2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txCustomerName"
                ErrorMessage="The Name Is Required" CssClass="fontcolor"></asp:RequiredFieldValidator>
        </div>
        <div class="left2">
            <span>CustomerGender</span>
        </div>
        <div class="middle2">
            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Selected="True">Male</asp:ListItem>
                <asp:ListItem Value="1">Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="right2">
        </div>
        <div class="left2">
            <span>CustomerAddress</span>
        </div>
        <div class="middle2">
            <asp:DropDownList ID="dropListAddresses" runat="server" AppendDataBoundItems="True"
                Width="140px">
            </asp:DropDownList>
        </div>
        <div class="right2">
            <asp:Button ID="btnCreateNewCustomer" runat="server" Text="Create New" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="labId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="labMethod" runat="server" Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>
