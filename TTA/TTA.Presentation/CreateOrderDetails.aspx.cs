using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTA.BLL;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTA.Presentation
{
    public partial class CreateOrderDetails : System.Web.UI.Page
    {
        /// <summary>
        /// provide a datasource for customer dropdownlist 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["firstNewRow"] = null;
                ViewState["orderId"] = null;
                CustomerList.DataSource = new Proxy().GetAllCustomers();
                CustomerList.DataTextField = "CustomerName";
                CustomerList.DataValueField = "CustomerId";
                CustomerList.DataBind();
            }
        }

        /// <summary>
        /// delete a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField hf = (HiddenField)GridViewOrderdetails.Rows[e.RowIndex].FindControl("OrderDetailId");
            DropDownList pn = (DropDownList)GridViewOrderdetails.Rows[e.RowIndex].FindControl("ProductNameList");
            TextBox q = (TextBox)GridViewOrderdetails.Rows[e.RowIndex].FindControl("Quantity");
            TextBox tp = (TextBox)GridViewOrderdetails.Rows[e.RowIndex].FindControl("TotalPrice");
            OrderDetailsBE OrderDetails = new OrderDetailsBE()
            {
                OrderDetailId = Convert.ToInt32(hf.Value.ToString()),
                OrderId = Convert.ToInt32(ViewState["orderId"]),
                ProductId = Convert.ToInt32(pn.SelectedValue),
                Quantity = Convert.ToInt32(q.Text),
                TotalPrice = Convert.ToDecimal(tp.Text)
            };
            new Proxy().DeleteOrderDetails(OrderDetails);
            GridViewOrderdetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(ViewState["orderId"]));
            GridViewOrderdetails.DataBind();
        }

        /// <summary>
        /// insert a order record and use this orderid to insert a new orderdetails 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateNewRow_Click(object sender, EventArgs e)
        {
            if (CustomerList.Text != "Please Select!")
            {
                if (ViewState["firstNewRow"] == null)
                {
                    OrderBE order = new OrderBE()
                    {
                        CreateTime = DateTime.Now,
                        CustomerId = int.Parse(CustomerList.SelectedValue.ToString()),
                        OrderStatusId = 1,
                        Customer = new CustomerBE() 
                        {
                            CustomerId = int.Parse(CustomerList.SelectedValue.ToString()),
                            Address = new AddressBE()
                            {
                                AddressId = 1
                            }
                        },
                        OrderStatus = new OrderStatusBE()
                        {
                            OrderStatusId = 1
                        }
                    };
                    ViewState["orderId"] = new Proxy().InsertOrder(order).OrderId;
                    OrderDetailsBE OrderDetails = new OrderDetailsBE()
                    {
                        OrderId = Convert.ToInt32(ViewState["orderId"]),
                        ProductId = 1,
                        Quantity = 0,
                        TotalPrice = 0
                    };
                    new Proxy().InsertOrderDetails(OrderDetails);
                    GridViewOrderdetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(ViewState["orderId"]));
                    GridViewOrderdetails.DataBind();
                    ViewState["firstNewRow"] = false;
                    CustomerList.Enabled = false;
                }
                else
                {
                    OrderDetailsBE OrderDetails = new OrderDetailsBE()
                    {
                        OrderId = Convert.ToInt32(ViewState["orderId"]),
                        ProductId = 1,
                        Quantity = 0,
                        TotalPrice = 0
                    };
                    new Proxy().InsertOrderDetails(OrderDetails);
                    GridViewOrderdetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(ViewState["orderId"]));
                    GridViewOrderdetails.DataBind();
                }
            }
        }

        /// <summary>
        /// tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Save_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('order successfully')</script>");
            //Response.Redirect("UpdateOrderDetails.aspx");
            Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('order successfully');document.location='UpdateOrderDetails.aspx'</script>");
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid when dropdownlist selectedindexchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        protected void ProductNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((sender as DropDownList).Parent.Parent) as GridViewRow;
            HiddenField hf = (HiddenField)gridRow.FindControl("OrderDetailId");
            DropDownList pn = (DropDownList)gridRow.FindControl("ProductNameList");
            TextBox q = (TextBox)gridRow.FindControl("Quantity");
            TextBox tp = (TextBox)gridRow.FindControl("TotalPrice");
            tp.Text = (new Proxy().GetProductById(Convert.ToInt32(pn.SelectedValue)).ProductPrice * Convert.ToInt32(q.Text)).ToString();
            OrderDetailsBE OrderDetails = new OrderDetailsBE()
            {
                OrderDetailId = Convert.ToInt32(hf.Value.ToString()),
                OrderId = Convert.ToInt32(ViewState["orderId"]),
                ProductId = Convert.ToInt32(pn.SelectedValue),
                Quantity = Convert.ToInt32(q.Text),
                TotalPrice = Convert.ToDecimal(tp.Text)
            };
            new Proxy().UpdateOrderDetails(OrderDetails);
            GridViewOrderdetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(ViewState["orderId"]));
            GridViewOrderdetails.DataBind();
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid when textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((sender as TextBox).Parent.Parent) as GridViewRow;
            HiddenField hf = (HiddenField)gridRow.FindControl("OrderDetailId");
            DropDownList pn = (DropDownList)gridRow.FindControl("ProductNameList");
            TextBox q = (TextBox)gridRow.FindControl("Quantity");
            TextBox tp = (TextBox)gridRow.FindControl("TotalPrice");
            tp.Text = (new Proxy().GetProductById(Convert.ToInt32(pn.SelectedValue)).ProductPrice * Convert.ToInt32(q.Text)).ToString();
            OrderDetailsBE OrderDetails = new OrderDetailsBE()
            {
                OrderDetailId = Convert.ToInt32(hf.Value.ToString()),
                OrderId = Convert.ToInt32(ViewState["orderId"]),
                ProductId = Convert.ToInt32(pn.SelectedValue),
                Quantity = Convert.ToInt32(q.Text),
                TotalPrice = Convert.ToDecimal(tp.Text)
            };
            new Proxy().UpdateOrderDetails(OrderDetails);
            GridViewOrderdetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(ViewState["orderId"]));
            GridViewOrderdetails.DataBind();
        }

        /// <summary>
        /// provide a datasource for productname dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ProductList = e.Row.Cells[0].FindControl("ProductNameList") as DropDownList;
                if (ProductList != null)
                {
                    ProductList.DataSource = new Proxy().SelectAllProduct();
                    ProductList.DataTextField = "ProductName";
                    ProductList.DataValueField = "ProductId";
                    ProductList.DataBind();
                    string pt = ((HiddenField)e.Row.FindControl("HFProduct")).Value.ToString();
                    ProductList.Items.FindByText(pt).Selected = true;
                }
            }
        }
    }
}
