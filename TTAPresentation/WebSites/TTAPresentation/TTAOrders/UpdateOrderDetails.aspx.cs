using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;
using TTA.Model;
 

namespace TTAPresentation.TTAOrders.Views
{
	public partial class UpdateOrderDetails :BasePage, IUpdateOrderDetailsView
    {
        #region
        private UpdateOrderDetailsPresenter _presenter;
        /// <summary>
        /// Used in the queryorderid to obtain the data posted
        /// </summary>
        private const string QueryOrderId = "id";
        /// <summary>
        /// Used as orderdetaildid textbox control
        /// </summary>
        private const string TxbOrderDetailId = "TxbOrderDetailId";
        /// <summary>
        /// Used as orderid textbox control
        /// </summary>
        private const string TxbOrderId = "TxbOrderId";
        /// <summary>
        /// Used as productname dropdownlist control
        /// </summary>
        private const string DdlProductName = "DdlProductName";
        /// <summary>
        /// Used as quantity textbox control
        /// </summary>
        private const string TxbQuantity = "TxbQuantity";
        /// <summary>
        /// Used as totalprice textbox control
        /// </summary>
        private const string TxbTotalPrice = "TxbTotalPrice";
        /// <summary>
        /// Used as orderdetaiid label control
        /// </summary>
        private const string LblOrderDetailId = "LblOrderDetailId";
        /// <summary>
        /// Used as orderid label control
        /// </summary>
        private const string LblOrderId = "LblOrderId";
        /// <summary>
        /// Used for quantity label control
        /// </summary>
        private const string LblQuantity = "LblQuantity";
        /// <summary>
        /// Used for totalprice label control
        /// </summary>
        private const string LblTotalPrice = "LblTotalPrice";
        /// <summary>
        /// Used as productid hiddenfield control
        /// </summary>
        private const string HFProductId = "HFProductId";
        /// <summary>
        /// Used for productname dropdownlist text field
        /// </summary>
        private const string ProductNameField = "ProductName";
        /// <summary>
        /// Used for productname dropdownlist value field
        /// </summary>
        private const string ProductIdField = "ProductId";
        /// <summary>
        /// Used as product hiddenfield control
        /// </summary>
        private const string HFProduct = "HFProduct";
        #endregion

        #region Private properties
        /// <summary>
        /// get the orderdetailsid updated
        /// </summary>
        public int OrderDetailsId { get; set; }
        /// <summary>
        /// get the orderid updated
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// get the productid updated
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// get the quantity updated
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// get the totalprice updated
        /// </summary>
        public decimal TotalPrice { get; set; }
        #endregion

        #region Business processes
        protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (!this.IsPostBack)
                {
                    this._presenter.OnViewInitialized();
                    GridViewOrderDetailsDataSource();
                }
                this._presenter.OnViewLoaded();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
		}

        /// <summary>
        /// Create a new presenter
        /// </summary>
		[CreateNew]
		public UpdateOrderDetailsPresenter Presenter
		{
			get
			{
				return this._presenter;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException("value");

				this._presenter = value;
				this._presenter.View = this;
			}
		}
        /// <summary>
        /// provide a datasource of two types for gridview
        /// </summary>
        private void GridViewOrderDetailsDataSource()
        {
            if (Request.QueryString[QueryOrderId] != null)
            {
                OrderId = Convert.ToInt32(Request.QueryString[QueryOrderId]);
                GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                GridViewOrderDetails.DataBind();
            }
            else
            {
                GridViewOrderDetails.DataSource = _presenter.GetAllOrderDetails();
                GridViewOrderDetails.DataBind();
            }
        }
        /// <summary>
        /// convert the gridview from item template to edit template 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewOrderDetails.EditIndex = e.NewEditIndex;
                GridViewOrderDetailsDataSource();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox txbOrderdetailsId = GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbOrderDetailId) as TextBox;
                TextBox txbOrderId = GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbOrderId) as TextBox;
                DropDownList ddlProductName = GridViewOrderDetails.Rows[e.RowIndex].FindControl(DdlProductName) as DropDownList;
                TextBox txbQuantity = GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbQuantity) as TextBox;
                TextBox txbTotalPrice = GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbTotalPrice) as TextBox;
                OrderDetailsId = Convert.ToInt32(txbOrderdetailsId.Text);
                OrderId = Convert.ToInt32(txbOrderId.Text);
                ProductId = Convert.ToInt32(ddlProductName.SelectedValue);
                Quantity = Convert.ToInt32(txbQuantity.Text);
                TotalPrice = Convert.ToDecimal(txbTotalPrice.Text);
                int orderCount = _presenter.GetOrderDetailsByOrderId().Count;
                for (int i = 0; i <= orderCount - 1; i++)
                {
                    if (OrderDetailsId < _presenter.GetOrderDetailsByOrderId()[i].OrderDetailId)
                    {
                        if (ProductId == _presenter.GetOrderDetailsByOrderId()[i].ProductId)
                        {
                            if (Request.QueryString[QueryOrderId] != null)
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('The order has existed the product ,the orderdetail has been merged into that one.');document.location='UpdateOrderDetails.aspx?id=" + Request.QueryString[QueryOrderId].ToString() + "'</script>");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('The order has existed the product ,the orderdetail has been merged into that one.');document.location='UpdateOrderDetails.aspx'</script>");
                            }
                            _presenter.DeleteOrderDetails();
                            OrderDetailsId = _presenter.GetOrderDetailsByOrderId()[i - 1].OrderDetailId;
                            Quantity += _presenter.GetOrderDetailsByOrderId()[i - 1].Quantity;
                            break;
                        }
                    }
                    else if (OrderDetailsId > _presenter.GetOrderDetailsByOrderId()[i].OrderDetailId)
                    {
                        if (ProductId == _presenter.GetOrderDetailsByOrderId()[i].ProductId)
                        {
                            if (Request.QueryString[QueryOrderId] != null)
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('The order has existed the product ,the orderdetail has been merged into that one.');document.location='UpdateOrderDetails.aspx?id=" + Request.QueryString[QueryOrderId].ToString() + "'</script>");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('The order has existed the product ,the orderdetail has been merged into that one.');document.location='UpdateOrderDetails.aspx'</script>");
                            }
                            _presenter.DeleteOrderDetails();
                            OrderDetailsId = _presenter.GetOrderDetailsByOrderId()[i].OrderDetailId;
                            Quantity += _presenter.GetOrderDetailsByOrderId()[i].Quantity;
                            break;
                        }
                    }

                }
                _presenter.UpdateOrderDetails();
                GridViewOrderDetails.EditIndex = -1;
                GridViewOrderDetailsDataSource();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// convert the gridview from edit template to item template 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridViewOrderDetails.EditIndex = -1;
                GridViewOrderDetailsDataSource();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// delete a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GridViewOrderDetails.EditIndex == -1)
                {
                    Label lblOrderdetailsId = (Label)GridViewOrderDetails.Rows[e.RowIndex].FindControl(LblOrderDetailId);
                    Label lblOrderId = (Label)GridViewOrderDetails.Rows[e.RowIndex].FindControl(LblOrderId);
                    Label lblQuantity = (Label)GridViewOrderDetails.Rows[e.RowIndex].FindControl(LblQuantity);
                    Label lblTotalPrice = (Label)GridViewOrderDetails.Rows[e.RowIndex].FindControl(LblTotalPrice);
                    HiddenField hfProductId = (HiddenField)GridViewOrderDetails.Rows[e.RowIndex].FindControl(HFProductId);
                    OrderDetailsId = Convert.ToInt32(lblOrderdetailsId.Text);
                    OrderId = Convert.ToInt32(lblOrderId.Text);
                    ProductId = Convert.ToInt32(hfProductId.Value.ToString());
                    Quantity = Convert.ToInt32(lblQuantity.Text);
                    TotalPrice = Convert.ToDecimal(lblTotalPrice.Text);
                }
                else
                {
                    TextBox txbOrderdetailsId = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbOrderDetailId);
                    TextBox txbOrderId = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbOrderId);
                    DropDownList ddlProductName = (DropDownList)GridViewOrderDetails.Rows[e.RowIndex].FindControl(DdlProductName);
                    TextBox txbQuantity = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbQuantity);
                    TextBox txbTotalPrice = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbTotalPrice);
                    OrderDetailsId = Convert.ToInt32(txbOrderdetailsId.Text);
                    OrderId = Convert.ToInt32(txbOrderId.Text);
                    ProductId = Convert.ToInt32(ddlProductName.SelectedValue);
                    Quantity = Convert.ToInt32(txbQuantity.Text);
                    TotalPrice = Convert.ToDecimal(txbTotalPrice.Text);
                }
                _presenter.CloseOrderDetails();
                GridViewOrderDetailsDataSource();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// paging 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewOrderDetails.EditIndex = -1;
                GridViewOrderDetails.PageIndex = e.NewPageIndex;
                GridViewOrderDetailsDataSource();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// provide a datasource for productname dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList ddlProductList = (DropDownList)e.Row.FindControl(DdlProductName);
                if (ddlProductList != null)
                {
                    ddlProductList.DataSource = _presenter.SelectAllProduct();
                    ddlProductList.DataTextField = ProductNameField;
                    ddlProductList.DataValueField = ProductIdField;
                    ddlProductList.DataBind();
                    string hfProduct = ((HiddenField)e.Row.FindControl(HFProduct)).Value.ToString();
                    ddlProductList.Items.FindByText(hfProduct).Selected = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// give a value to totalprice textbox through multiplying productprice and quantity after productname dropdownlist changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DdlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridRow = ((sender as DropDownList).Parent.Parent) as GridViewRow;
                DropDownList ddlProductName = (DropDownList)gridRow.FindControl(DdlProductName);
                TextBox txbQuantity = (TextBox)gridRow.FindControl(TxbQuantity);
                TextBox txbTotalPrice = (TextBox)gridRow.FindControl(TxbTotalPrice);
                ProductId = Convert.ToInt32(ddlProductName.SelectedValue);
                Quantity = Convert.ToInt32(txbQuantity.Text);
                txbTotalPrice.Text = (_presenter.GetProductById().ProductPrice * Quantity).ToString();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// give a value to totalprice textbox through multiplying productprice and quantity after quantity textbox changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridRow = ((sender as TextBox).Parent.Parent) as GridViewRow;
                DropDownList ddlProductName = (DropDownList)gridRow.FindControl(DdlProductName);
                TextBox txbQuantity = (TextBox)gridRow.FindControl(TxbQuantity);
                TextBox txbTotalPrice = (TextBox)gridRow.FindControl(TxbTotalPrice);
                ProductId = Convert.ToInt32(ddlProductName.SelectedValue);
                Quantity = Convert.ToInt32(txbQuantity.Text);
                txbTotalPrice.Text = (_presenter.GetProductById().ProductPrice * Quantity).ToString();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        #endregion


    }
}

