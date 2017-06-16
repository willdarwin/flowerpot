using System;
using Microsoft.Practices.ObjectBuilder;
using System.Collections.Generic;

namespace TTAPresentation.TTAOrders.Views
{
    public partial class OrderSearch : BasePage, IOrderSearchView
    {
        #region Private var
        
        /// <summary>
        /// The OrderSearch presenter.
        /// </summary>
        private OrderSearchPresenter _presenter;

        /// <summary>
        /// The sort expression string.
        /// </summary>
        private const string SortExprString = "SortExpression";

        /// <summary>
        /// The sort direction string.
        /// </summary>
        private const string SortDireString = "SortDirection";

        /// <summary>
        /// The default sort expression.
        /// </summary>
        private const string DefaultSortExpr = "OrderId";
        
        /// <summary>
        /// The default sort direction.
        /// </summary>
        private const string DefaultSortDire = "ASC";

        /// <summary>
        /// The current page index string.
        /// </summary>
        private const string PageIndexString = "PageIndex";

        /// <summary>
        /// The total page count string.
        /// </summary>
        private const string PageCountString = "PageCount";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                this.LoadFirstPage();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public OrderSearchPresenter Presenter
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

        #region Public properties

        /// <summary>
        /// The search condition input,customer name.
        /// </summary>
        public string CustomerName
        {
            get
            {
                return this.tbxCustomerName.Text;
            }
        }

        /// <summary>
        /// The search condition input, order created date, the start date of a date interval condition.
        /// </summary>
        public string StartDate
        {
            get
            {
                return this.tbxStartDate.Text;
            }
        }

        /// <summary>
        /// The search condition input, order created date, the end date of a date interval condition.
        /// </summary>
        public string EndDate
        {
            get
            {
                return this.tbxEndDate.Text;
            }
        }

        /// <summary>
        /// The search condition input,product name.
        /// </summary>
        public string ProductName
        {
            get
            {
                return this.tbxProductName.Text;
            }
        }

        /// <summary>
        /// Gets or sets the sort expression of the current page.
        /// </summary>
        public string SortExpression 
        {
            get
            {
                GetViewStateByName(SortExprString, DefaultSortExpr);
                return ViewState[SortExprString].ToString();
            }
            set 
            {
                ViewState[SortExprString] = value; 
            }
        }

        /// <summary>
        /// Gets or sets the sort direction of the current page.
        /// </summary>
        public string SortDirection
        {
            get
            {
                GetViewStateByName(SortDireString, DefaultSortDire);
                return ViewState[SortDireString].ToString();
            }
            set
            {
                ViewState[SortDireString] = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                GetViewStateByName(PageIndexString, 0);
                return Convert.ToInt32(ViewState[PageIndexString]);
            }
            set
            {
                ViewState[PageIndexString] = value;
                this.lblCurrentPage.Text = (value + 1).ToString();
            }
        }

        /// <summary>
        /// Gets or sets the total page count.
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                GetViewStateByName(PageCountString, 0);
                return Convert.ToInt32(ViewState[PageCountString]);
            }
            set
            {
                ViewState[PageCountString] = value;
                this.lblPageCount.Text = "of" + value.ToString();
            }
        }

        /// <summary>
        /// Get the page size of the current ASP page.
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.GVSearchResults.PageSize;
            }
        }

        /// <summary>
        /// The page index selected from the dropdownlist.
        /// </summary>
        public string SelectedPage
        {
            get
            {
                return this.ddlPageCount.Text;
            }
        }

        /// <summary>
        /// The page number list displayed in dropdownlist.
        /// </summary>
        public List<string> PageList
        {
            get
            {
                return this.PageList;
            }
            set
            {
                this.ddlPageCount.DataSource = value;
                this.ddlPageCount.DataBind();
            }
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Search result by conditions and display first page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchResult_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadFirstPage();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Display the first page of search result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadFirstPage();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Display the previous page of search result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrePage_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridViewDataBind(_presenter.ShowPrePage());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Display the next page of search result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridViewDataBind(_presenter.ShowNextPage());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Display the last page of search result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridViewDataBind(_presenter.ShowLastPage());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Display result of the selected page, when dropdownlist text changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.GridViewDataBind(_presenter.ShowPageChanged());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        ///  Get sorted results by input sortexpression and sortdirection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVSorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            try
            {
                this.GridViewDataBind(_presenter.Sorting(e.SortExpression.ToString()));
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        #endregion

        #region Common methods about page display.

        /// <summary>
        /// Bind data for gridview.
        /// </summary>
        /// <param name="oo"></param>
        private void GridViewDataBind(object dataObject)
        {
            this.GVSearchResults.DataSource = dataObject;
            this.GVSearchResults.DataBind();
            this.DisplaySomeComponets();
        }

        /// <summary>
        /// Gets the name of the viewstate.
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

        /// <summary>
        /// Load orderdetails result of first page.
        /// </summary>
        private void LoadFirstPage()
        {
            this.GridViewDataBind(_presenter.ShowFirstPage());
        }

        /// <summary>
        /// Enabled or not unenabled all page components.
        /// </summary>
        /// <param name="trueOrFalse"></param>
        private void EnableAllComponents(bool boolValue)
        {
            this.lblCurrentPage.Enabled = boolValue;
            this.lblPageCount.Enabled = boolValue;
            this.btnFirstPage.Enabled = boolValue;
            this.btnPrePage.Enabled = boolValue;
            this.btnNextPage.Enabled = boolValue;
            this.btnLastPage.Enabled = boolValue;
            this.ddlPageCount.Enabled = boolValue;
            this.lblToPage.Enabled = boolValue;
        }

        /// <summary>
        /// Set all page components visible or invisible.
        /// </summary>
        /// <param name="trueOrFalse"></param>
        private void DispalyAllComponents(bool boolValue)
        {
            this.lblCurrentPage.Visible = boolValue;
            this.lblPageCount.Visible = boolValue;
            this.btnFirstPage.Visible = boolValue;
            this.btnPrePage.Visible = boolValue;
            this.btnNextPage.Visible = boolValue;
            this.btnLastPage.Visible = boolValue;
            this.ddlPageCount.Visible = boolValue;
            this.lblToPage.Visible = boolValue;
        }

        /// <summary>
        /// Set some page componets visible.
        /// </summary>
        private void DisplaySomeComponets()
        {
            this.EnableAllComponents(true);
            this.DispalyAllComponents(true);
            if (Convert.ToInt32(this.CurrentPageIndex) <= 0)
            {
                this.btnFirstPage.Enabled = false;
                this.btnPrePage.Enabled = false;
                if (Convert.ToInt32(this.TotalPageCount) == 0)
                {
                    this.DispalyAllComponents(false);
                }
            }
            if (Convert.ToInt32(this.CurrentPageIndex) >= (Convert.ToInt32(this.TotalPageCount) - 1))
            {
                this.btnNextPage.Enabled = false;
                this.btnLastPage.Enabled = false;
            }
        }
        #endregion
    }
}