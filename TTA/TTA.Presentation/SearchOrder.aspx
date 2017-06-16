<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchOrder.aspx.cs" Inherits="TTA.Presentation.SearchOrder" %>  
     
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
    
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
      <title></title>  
      <link rel="stylesheet" href="Styles/ui-lightness/jquery-ui-1.8.22.custom.css"/>
        <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
        <script type="text/javascript" src="Scripts/jquery.ui.core.js"></script>
        <script type="text/javascript" src="Scripts/jquery.ui.widget.js"></script>
        <script type="text/javascript" src="Scripts/jquery.ui.datepicker.js"></script>
       
      <style type="text/css">  
                          .style1  
          {  
              font-size: xx-large;  
          }  
      </style>  
  </head>  
  <body>  
      <form id="form1" runat="server">  
      <div>  
          <p style="height: 76px; width: 908px; margin-left: 40px">  
              <strong style="margin-left: 40px"><span class="style1">Search Order</span></strong><br />  
              <br />  
          </p>  
          <asp:Panel ID="ConditionItems" runat="server" Direction="LeftToRight"   
              GroupingText="Search Criteria" Height="198px" style="margin-left: 162px"   
              Width="616px">  
              &nbsp;<asp:Label ID="CustomerNameLable" runat="server" Font-Size="Small" 
                  Height="20px" Text="CustomerName" Width="90px"></asp:Label>
              <asp:TextBox ID="CustomerName" runat="server" style="margin-top: 26px"></asp:TextBox>
              &nbsp;&nbsp;<asp:Label ID="ProductNameLable" runat="server" Font-Size="Small" Height="20px" 
                  Text="ProductName" Width="83px"></asp:Label>
              <asp:TextBox ID="ProductName" runat="server" style="margin-top: 26px"></asp:TextBox>
              <br />
              <asp:Label ID="OrderDate" runat="server" Font-Size="Small" Height="20px"   
                  Text="OrderDate" Width="60px"></asp:Label>  
              &nbsp;
              <asp:Label ID="OrderFrom" runat="server" Font-Size="Small" Height="20px" 
                  Text="From" Width="30px"></asp:Label>
              <asp:TextBox ID="StartDate" runat="server" style="margin-top: 26px" 
                  Width="117px"></asp:TextBox>
              &nbsp;&nbsp;<asp:Label ID="OrderTo" runat="server" Font-Size="Small" Height="20px" 
                  Text="To" Width="20px"></asp:Label>
              &nbsp;&nbsp;<asp:TextBox 
                  ID="EndDate" runat="server" style="margin-top: 26px" Width="117px"></asp:TextBox>
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
              <asp:Button ID="Search" runat="server" Text="Search" Width="78px"   
                  onclick="SearchByConditions" />  
              <br />
              <br />  
          </asp:Panel>  
        
      </div>  
      <asp:Panel ID="Panel1" runat="server" GroupingText="Search Result"   
          style="margin-left: 164px; margin-top: 14px" Width="619px">  
          <br />  
          <asp:GridView ID="SearchResult" runat="server" CellPadding="4" ForeColor="#333333"   
              GridLines="None" AutoGenerateColumns="False" Width="544px"   
              AllowSorting="True" onsorting="GVSorting" AllowPaging="True" PageSize="3" >  
              <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />  
              <Columns>  
                  <asp:BoundField DataField="OrderId" HeaderText="OrderId" SortExpression="OrderId" />  
                  <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate"/>  
                  <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName"/>  
                  <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"/>  
                  <asp:BoundField DataField="TotalPrice" HeaderText="TotalPrice" SortExpression="TotalPrice"/>  
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

          <PagerTemplate>
                <table style="border-color: inherit; border-width: 0px; border-style: ridge; width: 616px; height: 10px;" 
                    align="center">
                <tr>
                    <td style="border-bottom-style: ridge; width: 100%; text-align: center">
                        <asp:Button ID="btnFirst" runat="server" BackColor="White" BorderStyle="None" 
                            onclick="btnFirst_Click" Text="|&lt;" />
                        <asp:Button ID="btnPre" runat="server" BackColor="White" BorderStyle="None" 
                            onclick="bthPre_Click" Text="&lt;&lt;" />
                        &nbsp;<asp:Label ID="lbCurrentPage" runat="server" BackColor="White" 
                            BorderStyle="None"></asp:Label>
                        <asp:Button ID="btnNext" runat="server" BackColor="White" BorderStyle="None" 
                            onclick="btnNext_Click" Text="&gt;&gt;" />
                        <asp:Button ID="btnLast" runat="server" BackColor="White" BorderStyle="None" 
                            onclick="btnLast_Click" Text="&gt;|" />
                    </td>
                </tr>
                </table>
               </PagerTemplate>

      </asp:Panel>  
      </form>  
  </body>
  <script>
       $(function () {
           $("#StartDate").datepicker({ dateFormat: "yy-mm-dd" });
           $("#EndDate").datepicker({ dateFormat: "yy-mm-dd" });
       });
        </script>
  </html>  
     

