using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;

namespace TTAPresentation.TTAOrders.Views
{

    public partial class OrderList : BasePage, IOrderListView
    {
        #region field
        /// <summary>
        /// OrderList presenter.
        /// </summary>
        private OrderListPresenter _presenter;

        /// <summary>
        /// Curent Page Index Name
        /// </summary>
        private const string CurrentPageIndexString = "CurrentPageIndex";

        /// <summary>
        /// Tatal page count string.
        /// </summary>
        private const string TotalPageCountString = "TotalPageCount";

        /// <summary>
        /// Customer name string.
        /// </summary>
        private const string CustomerNameString = "Name";

        /// <summary>
        /// Start date string.
        /// </summary>
        private const string StartDateString = "StartDate";

        /// <summary>
        /// End date string.
        /// </summary>
        private const string EndDateString = "EndDate";

        /// <summary>
        /// Initial of current page.
        /// </summary>
        private int InitialOfCurrentPage = 0;

        /// <summary>
        /// Initial of total page.
        /// </summary>
        private int InitialOfTotalPageCount = 1;

        /// <summary>
        /// initial page index 0.
        /// </summary>
        private int InitialPageIndex = 0;

        /// <summary>
        /// Redirect string.
        /// </summary>
        private const string RedirectString = "UpdateOrderDetails.aspx?id=";

        private const string CloseButton = "Close";

        private const string DeleteButton = "Delete";

        private const string DetailButton = "Detail";

        private const string IdLable = "labId";
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        /// <value>
        /// The index of the current page.
        /// </value>
        public int CurrentPageIndex
        {
            get
            {
                GetViewStateByName(CurrentPageIndexString, InitialOfCurrentPage);
                return Convert.ToInt32(ViewState[CurrentPageIndexString]);
            }
            set { ViewState[CurrentPageIndexString] = value; }
        }

        /// <summary>
        /// Gets or sets the total page count.
        /// </summary>
        /// <value>
        /// The total page count.
        /// </value>
        public int TotalPageCount
        {
            get
            {
                GetViewStateByName(TotalPageCountString, InitialOfTotalPageCount);
                return Convert.ToInt32(ViewState[TotalPageCountString]);
            }
            set { ViewState[TotalPageCountString] = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                GetViewStateByName(CustomerNameString, string.Empty);
                return ViewState[CustomerNameString].ToString();
            }
            set
            {
                ViewState[CustomerNameString] = value;
            }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public string StartDate
        {
            get
            {
                GetViewStateByName(StartDateString, string.Empty);
                return ViewState[StartDateString].ToString();
            }
            set
            {
                ViewState[StartDateString] = value;
            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public string EndDate
        {
            get
            {
                GetViewStateByName(EndDateString, string.Empty);
                return ViewState[EndDateString].ToString();
            }
            set
            {
                ViewState[EndDateString] = value;
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this._presenter.OnViewInitialized();
                    rptOrderList.DataSource = GetOrderList();
                    rptOrderList.DataBind();
                }
                this._presenter.OnViewLoaded();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        [CreateNew]
        public OrderListPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }

        #region control event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Name = this.CustomerName.Text.Trim();
            StartDate = this.txtDateStartCondition.Text.Trim();
            EndDate = this.txtDateEndCondition.Text.Trim();
            CurrentPageIndex = 0;
            TotalPageCount = 0;

            try
            {
                rptOrderList.DataSource = GetOrderList();
                rptOrderList.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the ItemCommand event of the rptOrderList control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
        protected void rptOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == DeleteButton)
            {
                try
                {
                    Id = Convert.ToInt32(e.CommandArgument);

                    _presenter.DeleteOrder(Id);
                    rptOrderList.DataSource = GetOrderList();
                    rptOrderList.DataBind();
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }
            if (e.CommandName == DetailButton)
            {
                Response.Redirect(RedirectString + e.CommandArgument.ToString());
            }
        }

        /// <summary>
        /// Handles the Click event of the CloseInBatch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void CloseInBatch_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem repeaterItem in rptOrderList.Items)
                {
                    CheckBox myCheckBox = (CheckBox)repeaterItem.FindControl(CloseButton);
                    Label orderIdLabel = (Label)repeaterItem.FindControl(IdLable);
                    if (myCheckBox.Checked)
                    {
                        Id = Convert.ToInt32(orderIdLabel.Text);
                        _presenter.CloseOrder(Id);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            rptOrderList.DataSource = GetOrderList();
            rptOrderList.DataBind();
        }

        /// <summary>
        /// Handles the Click event of the lb_first control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void lb_first_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.GetFirstPage();
                rptOrderList.DataSource = GetOrderList();
                rptOrderList.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the lb_prv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void lb_prv_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.GetPrePage();
                rptOrderList.DataSource = GetOrderList();
                rptOrderList.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the lb_next control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void lb_next_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.GetNextPage();
                rptOrderList.DataSource = GetOrderList();
                rptOrderList.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the lb_last control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void lb_last_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.GetLastPage();
                rptOrderList.DataSource = GetOrderList();
                rptOrderList.DataBind();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
        #endregion

        #region private method
        /// <summary>
        /// Get Data Source.
        /// </summary>
        /// <returns></returns>
        private PagedDataSource GetOrderList()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = _presenter.GetOrdersByCondition(Name, StartDate, EndDate);

            pds.AllowPaging = true;
            pds.PageSize = 8;
            TotalPageCount = pds.PageCount;
            pds.CurrentPageIndex = CurrentPageIndex;
            int currentPage = CurrentPageIndex + 1;

            if (pds.Count != 0)
            {
                this.lb_current.Text = (currentPage).ToString();
                this.lb_total.Text = TotalPageCount.ToString();
            }
            else
            {
                this.lb_current.Text = InitialPageIndex.ToString();
                this.lb_total.Text = InitialPageIndex.ToString();
            }

            if (TotalPageCount != 0 && TotalPageCount != 1)
            {
                lb_first.Enabled = true;
                lb_last.Enabled = true;

            }
            else
            {
                lb_first.Enabled = false;
                lb_last.Enabled = false;
            }

            if (currentPage < TotalPageCount)
            {
                lb_next.Enabled = true;
                lb_last.Enabled = true;
            }
            else
            {
                lb_next.Enabled = false;
                lb_last.Enabled = false;
            }
            if (currentPage > 1)
            {
                lb_prv.Enabled = true;
                lb_first.Enabled = true;
            }
            else
            {
                lb_prv.Enabled = false;
                lb_first.Enabled = false;
            }

            return pds;
        }

        /// <summary>
        /// Gets the name of the view state by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <returns></returns>
        private object GetViewStateByName(string name, object initialValue)
        {
            if (ViewState[name] == null)
                ViewState[name] = initialValue;
            return ViewState[name];
        }
        #endregion
    }
}

