<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TTA.Presentation.OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>OrderList</title>
    <link rel="stylesheet" href="Styles/ui-lightness/jquery-ui-1.8.22.custom.css"/>
    <link rel="stylesheet" type="text/css" href="Styles/Styles.css" />
    <link rel="stylesheet" type="text/css" href="Styles/form.css" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.core.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtDateStartCondition").datepicker({ dateFormat: "yy-mm-dd" });
            $("#txtDateEndCondition").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Search Order" Height="56px">
        <asp:Label ID="labName" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="labStartDate" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="labEndDate" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp; CustomerName
        <asp:TextBox ID="CustomerName" runat="server" Height="25px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OrderDate
        <%--<asp:DropDownList ID="CompareSymbol" runat="server">
            <asp:ListItem Value="&gt;=">>=</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
            <asp:ListItem Value="&lt;="><=</asp:ListItem>
        </asp:DropDownList>--%>
        &nbsp; from &nbsp;
        <asp:TextBox ID="txtDateStartCondition" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        &nbsp; to &nbsp;
        <asp:TextBox ID="txtDateEndCondition" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  class="btn" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Order List" Height="408px"
        Style="margin-top: 32px">
        &nbsp;&nbsp;
        <br />
        &nbsp;
        <div class="contentcontainer">
            <div class="headings altheading">
                <h2>
                    Order List</h2>
            </div>
            <div class="contentbox">
                <asp:Repeater ID="rptOrderList" runat="server" OnItemCommand="rptOrderList_ItemCommand">
                    <HeaderTemplate>
                        <table border="0" width="100%">
                            <tr>
                                <th>
                                </th>
                                <th align="left">
                                    Customer Name
                                </th>
                                <th align="left">
                                    Order Date
                                </th>
                                <th align="left">
                                    Order Status
                                </th>
                                <th>
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>                     
                                <asp:CheckBox ID="Close" runat="server" Visible = ' <%#Convert.ToBoolean(Eval("OrderCheckBoxFlag")) %>' />
                                <asp:Label ID="labId" runat="server" Text='<%#Eval("OrderId")%>' Visible="False"  ></asp:Label>
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
                                <asp:Button runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("OrderId")%>'
                                    OnClientClick='return confirm("delete?")' />
                                <asp:Button runat="server" Text="Detail" CommandName="Detail" CommandArgument='<%#Eval("OrderId")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="extrabottom">
                    <div class="bulkactions">
                    <asp:Button ID="CloseInBatch" runat="server" Text="Close in Batch" OnClick="CloseInBatch_Click"
            OnClientClick='return confirm("Close?")' class="btn" />
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
