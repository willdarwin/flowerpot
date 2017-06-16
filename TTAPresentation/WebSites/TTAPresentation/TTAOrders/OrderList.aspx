<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="TTAPresentation.TTAOrders.Views.OrderList"
    Title="OrderList" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content1" ContentPlaceHolderID="TTAhead" runat="Server">
    <link rel="stylesheet" href="../Styles/jquery-ui.css" />
    <script type="text/javascript" src="../Js/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.core.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../Js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtDateStartCondition.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
            $("#<%=txtDateEndCondition.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
        });

        function SelectAllCheckBox(obj) {
            var form = document.forms[0];
            for (i = 0; i < form.elements.length; i++) {
                if (form.elements[i].type == "checkbox") {
                    form.elements[i].checked = obj.checked;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Order List</h1>
    <center>
        <asp:Panel ID="Panel1" CssClass="searchpanel" runat="server" GroupingText="Search Conditions"
            Height="100px">
            <div class="left">
                <span>Customer Name</span>
                <asp:TextBox ID="CustomerName" runat="server"></asp:TextBox>
            </div>
            <div class="right">
            </div>
            <div class="left">
                <span>Date From</span>
                <asp:TextBox ID="txtDateStartCondition" runat="server"></asp:TextBox>
            </div>
            <div class="right">
                <span>To</span>
                <asp:TextBox ID="txtDateEndCondition" runat="server"></asp:TextBox>
            </div>
            <div class="floatright">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    Width="75px" class="btn" />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="Order List" Height="408px">
            <div class="contentcontainer">
                <div class="headings altheading">
                    <div class="extrabottom">
                        <div class="bulkactions">
                            <div class="floatright">
                                <asp:Button ID="CloseInBatch" runat="server" Text="Close Seleted Orders" OnClick="CloseInBatch_Click"
                                    OnClientClick='return confirm("Close all the selected orders?")' class="btn" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="contentbox">
                    <asp:Repeater ID="rptOrderList" runat="server" OnItemCommand="rptOrderList_ItemCommand">
                        <HeaderTemplate>
                            <table width="100%" cellspacing="0">
                                <tr class="head">
                                    <td>
                                        <input type="checkbox" id="CheckAll" runat="server" onclick="SelectAllCheckBox(this);" />
                                    </td>
                                    <td>
                                        Customer Name
                                    </td>
                                    <td>
                                        Order Date
                                    </td>
                                    <td>
                                        Order Status
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr class="low">
                                    <td>
                                        <asp:CheckBox ID="Close" runat="server" Enabled='<%#Convert.ToBoolean(Eval("OrderCheckBoxFlag")) %>'
                                            Visible=' <%#Convert.ToBoolean(Eval("OrderCheckBoxFlag")) %>' />
                                        <asp:Label ID="labId" runat="server" Text='<%#Eval("OrderId")%>' Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("Customer.CustomerName")%>
                                    </td>
                                    <td>
                                        <%#Eval("CreateTime")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderStatus.StatusName") %>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("OrderId")%>'
                                            OnClientClick='return confirm("Delete this order?")' />
                                        <asp:Button ID="Button2" runat="server" Text="Detail" CommandName="Detail" CommandArgument='<%#Eval("OrderId")%>' />
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tbody>
                                <tr class="alt">
                                    <td>
                                        <asp:CheckBox ID="Close" runat="server" Enabled='<%#Convert.ToBoolean(Eval("OrderCheckBoxFlag")) %>'
                                            Visible=' <%#Convert.ToBoolean(Eval("OrderCheckBoxFlag")) %>' />
                                        <asp:Label ID="labId" runat="server" Text='<%#Eval("OrderId")%>' Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("Customer.CustomerName")%>
                                    </td>
                                    <td>
                                        <%#Eval("CreateTime")%>
                                    </td>
                                    <td>
                                        <%#Eval("OrderStatus.StatusName") %>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("OrderId")%>'
                                            OnClientClick='return confirm("delete?")' />
                                        <asp:Button ID="Button2" runat="server" Text="Detail" CommandName="Detail" CommandArgument='<%#Eval("OrderId")%>' />
                                    </td>
                                </tr>
                            </tbody>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:LinkButton ID="lb_first" runat="server" OnClick="lb_first_Click" Enabled="false"><<</asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lb_prv" runat="server" OnClick="lb_prv_Click" Enabled="false"><</asp:LinkButton>&nbsp
                    <asp:Label ID="lb_current" runat="server" Text="0"></asp:Label>
                    <span>of</span>
                    <asp:Label ID="lb_total" runat="server" Text="0"></asp:Label>
                    <asp:LinkButton ID="lb_next" runat="server" OnClick="lb_next_Click" Enabled="false">></asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lb_last" runat="server" OnClick="lb_last_Click" Enabled="false">>></asp:LinkButton>
                    <div style="clear: both;">
                    </div>
                </div>
            </div>
        </asp:Panel>
    </center>
</asp:Content>
