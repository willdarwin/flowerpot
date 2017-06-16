using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
	public partial class CreateOrderDetails : BasePage, ICreateOrderDetailsView
    {
        #region Private fields

        private CreateOrderDetailsPresenter _presenter;
        /// <summary>
        /// Used for customername dropdownlist value field
        /// </summary>
        private const string CustomerIdField = "CustomerId";
        /// <summary>
        /// Used for customername dropdownlist text field
        /// </summary>
        private const string CustomerNameField = "CustomerName";
        /// <summary>
        /// Used for viewstate to record whether it's the first to press the create new orderdetails button or not
        /// </summary>
        private const string FirstNewRowVS = "firstNewRow";
        /// <summary>
        /// Used for viewstate to record the orderid
        /// </summary>
        private const string OrderIdVS = "orderId";
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
        /// Used as orderdetail hiddenfield control
        /// </summary>
        private const string HFOrderDetailId = "HFOrderDetailId";
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

        #region Public properties
        /// <summary>
        /// get selected value in customerlist
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// get the orderid inserted
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// get the orderdetailsid inserted
        /// </summary>
        public int OrderDetailsId { get; set; }

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
        /// <summary>
        /// provide a datasource for customer dropdownlist 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (!this.IsPostBack)
                {
                    this._presenter.OnViewInitialized();
                    ViewState[FirstNewRowVS] = null;
                    ViewState[OrderIdVS] = null;
                    DdlCustomer.DataSource = _presenter.GetAllCustomers();
                    DdlCustomer.DataTextField = CustomerNameField;
                    DdlCustomer.DataValueField = CustomerIdField;
                    DdlCustomer.DataBind();
                }
                this._presenter.OnViewLoaded();
            }
            catch (Exception ex)
            {              
                this.ShowErrorMessage(ex);
            }
		}

		[CreateNew]
		public CreateOrderDetailsPresenter Presenter
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
        /// delete a piece of orderdetails record by its corresponding orderdetailsid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewOrderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                OrderDetailsId = Convert.ToInt32(GridViewOrderDetails.DataKeys[e.RowIndex].Values[0].ToString());
                OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                DropDownList ddlProductName = (DropDownList)GridViewOrderDetails.Rows[e.RowIndex].FindControl(DdlProductName);
                TextBox txbQuantity = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbQuantity);
                TextBox txbTotalPrice = (TextBox)GridViewOrderDetails.Rows[e.RowIndex].FindControl(TxbTotalPrice);
                ProductId = Convert.ToInt32(ddlProductName.SelectedValue);
                Quantity = Convert.ToInt32(txbQuantity.Text);
                TotalPrice = Convert.ToDecimal(txbTotalPrice.Text);
                _presenter.DeleteOrderDetails();
                GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                GridViewOrderDetails.DataBind();
            }
            catch (Exception ex)
            {                
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// insert a order record and use this orderid to insert a new orderdetails 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCreateNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (DdlCustomer.Text != "Please Select!")
                {
                    if (ViewState[FirstNewRowVS] == null)
                    {
                        CustomerName = DdlCustomer.SelectedValue;
                        ViewState[OrderIdVS] = _presenter.InsertOrder().OrderId;
                        OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                        _presenter.InsertOrderDetails();
                        GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                        GridViewOrderDetails.DataBind();
                        ViewState[FirstNewRowVS] = false;
                        DdlCustomer.Enabled = false;
                    }
                    else
                    {
                        OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                        _presenter.OpenOrder();
                        _presenter.InsertOrderDetails();
                        GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                        GridViewOrderDetails.DataBind();
                    }
                }
                BtnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// tips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                int orderCount = _presenter.GetOrderDetailsByOrderId().Count;
                if (orderCount == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "redirect", "<script>alert('The order has no orderdetails , save failed.');document.location='CreateOrderDetails.aspx'</script>");
                }
                else
                {
                    for (int i = 0; i <= orderCount - 1; i++)
                    {
                        if (i != orderCount - 1)
                        {
                            for (int j = i + 1; j <= orderCount - 1; j++)
                            {
                                if (_presenter.GetOrderDetailsByOrderId()[i].ProductId == _presenter.GetOrderDetailsByOrderId()[j].ProductId)
                                {
                                    OrderDetailsId = _presenter.GetOrderDetailsByOrderId()[i].OrderDetailId;
                                    ProductId = _presenter.GetOrderDetailsByOrderId()[i].ProductId;
                                    Quantity = _presenter.GetOrderDetailsByOrderId()[j].Quantity + _presenter.GetOrderDetailsByOrderId()[i].Quantity;
                                    TotalPrice = _presenter.GetOrderDetailsByOrderId()[j].TotalPrice + _presenter.GetOrderDetailsByOrderId()[i].TotalPrice;
                                    _presenter.UpdateOrderDetails();
                                    OrderDetailsId = _presenter.GetOrderDetailsByOrderId()[j].OrderDetailId;
                                    ProductId = _presenter.GetOrderDetailsByOrderId()[j].ProductId;
                                    Quantity = _presenter.GetOrderDetailsByOrderId()[j].Quantity;
                                    TotalPrice = _presenter.GetOrderDetailsByOrderId()[j].TotalPrice;
                                    _presenter.DeleteOrderDetails();
                                    orderCount--;
                                    j--;
                                }
                            }
                        }
                    }
                    orderCount = _presenter.GetOrderDetailsByOrderId().Count;
                    for (int k = 0; k <= orderCount - 1; k++)
                    {
                        if (_presenter.GetOrderDetailsByOrderId()[k].Quantity == 0)
                        {
                            OrderDetailsId = _presenter.GetOrderDetailsByOrderId()[k].OrderDetailId;
                            ProductId = _presenter.GetOrderDetailsByOrderId()[k].ProductId;
                            Quantity = _presenter.GetOrderDetailsByOrderId()[k].Quantity;
                            TotalPrice = _presenter.GetOrderDetailsByOrderId()[k].TotalPrice;
                            _presenter.DeleteOrderDetails();
                            orderCount--;
                            k--;
                        }
                    }
                    orderCount = _presenter.GetOrderDetailsByOrderId().Count;
                    if (orderCount > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "pagejump", "<script>alert('Save successfully');document.location='UpdateOrderDetails.aspx?id=" + OrderId.ToString() + "'</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "redirect", "<script>alert('The order has no orderdetails , save failed.');document.location='CreateOrderDetails.aspx'</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid when dropdownlist selectedindexchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        protected void DdlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridRow = ((sender as DropDownList).Parent.Parent) as GridViewRow;
                HiddenField hf = (HiddenField)gridRow.FindControl(HFOrderDetailId);
                DropDownList pn = (DropDownList)gridRow.FindControl(DdlProductName);
                TextBox q = (TextBox)gridRow.FindControl(TxbQuantity);
                TextBox tp = (TextBox)gridRow.FindControl(TxbTotalPrice);
                ProductId = Convert.ToInt32(pn.SelectedValue);
                tp.Text = (_presenter.GetProductById().ProductPrice * Convert.ToInt32(q.Text)).ToString();
                OrderDetailsId = Convert.ToInt32(hf.Value.ToString());
                OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                ProductId = Convert.ToInt32(pn.SelectedValue);
                Quantity = Convert.ToInt32(q.Text);
                TotalPrice = Convert.ToDecimal(tp.Text);
                _presenter.UpdateOrderDetails();
                GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                GridViewOrderDetails.DataBind();
            }
            catch (Exception ex)
            {               
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// update a piece of orderdetails record by its corresponding orderdetailsid when textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TxbQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridRow = ((sender as TextBox).Parent.Parent) as GridViewRow;
                HiddenField hf = (HiddenField)gridRow.FindControl(HFOrderDetailId);
                DropDownList pn = (DropDownList)gridRow.FindControl(DdlProductName);
                TextBox q = (TextBox)gridRow.FindControl(TxbQuantity);
                TextBox tp = (TextBox)gridRow.FindControl(TxbTotalPrice);
                ProductId = Convert.ToInt32(pn.SelectedValue);
                tp.Text = (_presenter.GetProductById().ProductPrice * Convert.ToInt32(q.Text)).ToString();
                OrderDetailsId = Convert.ToInt32(hf.Value.ToString());
                ProductId = Convert.ToInt32(pn.SelectedValue);
                OrderId = Convert.ToInt32(ViewState[OrderIdVS]);
                Quantity = Convert.ToInt32(q.Text);
                TotalPrice = Convert.ToDecimal(tp.Text);
                _presenter.UpdateOrderDetails();
                GridViewOrderDetails.DataSource = _presenter.GetOrderDetailsByOrderId();
                GridViewOrderDetails.DataBind();
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
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlProductName = e.Row.Cells[0].FindControl(DdlProductName) as DropDownList;
                    if (ddlProductName != null)
                    {
                        ddlProductName.DataSource = _presenter.SelectAllProduct();
                        ddlProductName.DataTextField = ProductNameField;
                        ddlProductName.DataValueField = ProductIdField;
                        ddlProductName.DataBind();
                        string pt = ((HiddenField)e.Row.FindControl(HFProduct)).Value.ToString();
                        ddlProductName.Items.FindByText(pt).Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {            
                this.ShowErrorMessage(ex);
            }
        }
        #endregion
    }
}

