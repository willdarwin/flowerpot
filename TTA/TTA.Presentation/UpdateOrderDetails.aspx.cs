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
    public partial class UpdateOrderDetails : System.Web.UI.Page
    {
        #region gridview datasource
        /// <summary>
        /// provide a datasource of two types for gridview
        /// </summary>
        private void GridViewOrderDetailsDataSource()
        {
            //Proxy client = new Proxy();
            if (Request.QueryString["id"] != null)
            {
                GridViewOrderDetails.DataSource = new Proxy().GetOrderDetailsByOrderId(Convert.ToInt32(Request.QueryString["id"]));
                GridViewOrderDetails.DataBind();
            }
            else
            {
                GridViewOrderDetails.DataSource = new Proxy().GetAllOrderDetails();
                GridViewOrderDetails.DataBind();
            }
        }
        #endregion

        /// <summary>
        /// load the gridview according to needs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewOrderDetailsDataSource();
            }
        }

        /// <summary>
        /// convert the gridview from item template to edit template 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOrderDetails.EditIndex = e.NewEditIndex;
            GridViewOrderDetailsDataSource();
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox orderdetailsId = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl("OrderDetailId");
            TextBox orderId = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl("OrderId");
            DropDownList productName = (DropDownList)GridViewOrderDetails.Rows[e.RowIndex].FindControl("ProductName");
            TextBox quantity = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl("Quantity");
            TextBox totalPrice = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl("TotalPrice");
            OrderDetailsBE OrderDetails = new OrderDetailsBE()
            {
                OrderDetailId = Convert.ToInt32(orderdetailsId.Text),
                OrderId = Convert.ToInt32(orderId.Text),
                ProductId = Convert.ToInt32(productName.SelectedValue),
                Quantity = Convert.ToInt32(quantity.Text),
                TotalPrice = Convert.ToDecimal(totalPrice.Text)
            };
            new Proxy().UpdateOrderDetails(OrderDetails);
            GridViewOrderDetails.EditIndex = -1;
            GridViewOrderDetailsDataSource();
        }

        /// <summary>
        /// convert the gridview from edit template to item template 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewOrderDetails.EditIndex = -1;
            GridViewOrderDetailsDataSource();
        }

        /// <summary>
        /// delete a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string orderid = GridViewOrderDetails.DataKeys[e.RowIndex].Values[0].ToString();
            new OrderDetailsService().DeleteOrderDetails(Convert.ToInt32(orderid));
            GridViewOrderDetailsDataSource();
        }

        /// <summary>
        /// paging 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewOrderDetails.PageIndex = e.NewPageIndex;
            GridViewOrderDetailsDataSource();
        }

        /// <summary>
        /// provide a datasource for productname dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList ProductList = (DropDownList)e.Row.FindControl("ProductName");
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

        /// <summary>
        /// give a value to totalprice textbox through multiplying productprice and quantity after productname dropdownlist changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((sender as DropDownList).Parent.Parent) as GridViewRow;
            DropDownList productName = (DropDownList)gridRow.FindControl("ProductName");
            TextBox quantity = (TextBox)gridRow.FindControl("Quantity");
            TextBox totalPrice = (TextBox)gridRow.FindControl("TotalPrice");
            totalPrice.Text = (new Proxy().GetProductById(Convert.ToInt32(productName.SelectedValue)).ProductPrice * Convert.ToInt32(quantity.Text)).ToString();
        }

        /// <summary>
        /// give a value to totalprice textbox through multiplying productprice and quantity after quantity textbox changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gridRow = ((sender as TextBox).Parent.Parent) as GridViewRow;
            DropDownList productName = (DropDownList)gridRow.FindControl("ProductName");
            TextBox quantity = (TextBox)gridRow.FindControl("Quantity");
            TextBox totalPrice = (TextBox)gridRow.FindControl("TotalPrice");
            totalPrice.Text = (new Proxy().GetProductById(Convert.ToInt32(productName.SelectedValue)).ProductPrice * Convert.ToInt32(quantity.Text)).ToString();
        }
    }
}