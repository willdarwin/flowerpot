<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAllCustomers.aspx.cs"
    Inherits="TTAPresentation.TTACustomer.Views.ShowAllCustomers" Title="ShowAllCustomers"
    MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <style type="text/css">
        .floatright
        {
            float: right;
            margin-right: 50px;
        }
    </style>
    <h1>
        ShowAllCustomers</h1>
    <div class="floatright">
        <asp:Button ID="btnCreateNewCustomer" runat="server" Text="Create New Customer" OnClick="btnCreateNewCustomer_Click" />
    </div>
    <asp:Panel ID="panelProductList" runat="server" class="middle" GroupingText="CustomerList" HorizontalAlign="Center">
        <asp:Repeater ID="reapterCustomers" runat="server" OnItemCommand="reapterCustomers_ItemCommand"
            OnItemDataBound="reapterCustomers_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" cellspacing="0">
                    <thead>
                        <tr class="head">
                            <td>
                                Customer Id
                            </td>
                            <td>
                                Customer Name
                            </td>
                            <td>
                                Customer Gender
                            </td>
                            <td>
                                Customer Address
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="low">
                    <td>
                        <%#Eval("CustomerId") %>
                    </td>
                    <td>
                        <%#Eval("CustomerName")%>
                    </td>
                    <td>
                        <%# ((TTA.Model.CustomerBE)(Container.DataItem)).CustomerGender ? "Female" : "Male"%>
                    </td>
                    <td>
                        <%#Eval("Address")%>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("CustomerId") %>' />
                        <asp:Button ID="Button2" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("CustomerId") %>' OnClientClick='return confirm("delete?")' CausesValidation="False" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alt">
                    <td>
                        <%#Eval("CustomerId") %>
                    </td>
                    <td>
                        <%#Eval("CustomerName")%>
                    </td>
                    <td>
                        <%# ((TTA.Model.CustomerBE)(Container.DataItem)).CustomerGender ? "Female" : "Male"%>
                    </td>
                    <td>
                        <%#Eval("Address")%>
                    </td>
                    <td>
                    <asp:Button ID="Button3" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("CustomerId") %>' />
                        <asp:Button ID="Button2"  OnClientClick='return confirm("delete?")' runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("CustomerId") %>' CausesValidation="False" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
