using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTA.BLL;
using TTA.Model;
using TTA.ServiceProxy;


namespace TTA.Presentation
{
    public partial class SearchOrder : System.Web.UI.Page
    {
        /// <summary>
        /// When page load first time, initialize current page parameter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ViewState["sortExpression"] = "OrderId";
                ViewState["sortDirection"] = "ASC";
                ViewState["pageIndex"] = 0;
                ViewState["pageSize"] = 0;
                ViewState["pageCount"] = 0;
                ComponentShow(false);
            }
        }

        /// <summary>
        /// Call the SearchByConditions(...) method from BBLService, get the data and bind them to gridview. 
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="pageIndex"></param>
        public void QueryDB(string sortExpression, string sortDirection, int pageIndex)
        {
            string customerName, productName, startDate, endDate;
            int rowCount, pageStart, pageEnd, pageSize, pageCount;

            customerName = CustomerName.Text;
            productName = ProductName.Text;
            startDate = StartDate.Text;
            endDate = EndDate.Text;
            
            pageSize = SearchResult.PageSize;
            ViewState["pageSize"] = pageSize;

            pageStart = pageSize * pageIndex + 1;
            pageEnd = pageSize * (pageIndex + 1);

            Proxy searchproxy = new Proxy();
            OrderSearchParameterBE orderSearchParameterBE = new OrderSearchParameterBE() 
            {
                CustomerName = customerName,
                StartDate = startDate,
                EndDate = endDate,
                ProductName = productName,
                SortExpression = sortExpression,
                SortDirection = sortDirection,
                PageStart = pageStart,
                PageEnd = pageEnd,  
            };
            List<OrderSearchResultBE> orderSearchResultBEList = searchproxy.SearchByConditions(orderSearchParameterBE, out rowCount);

            pageCount = (int)Math.Ceiling((double)rowCount/(double)pageSize);
            ViewState["pageCount"] = pageCount;

            SearchResult.DataSource = orderSearchResultBEList;
            SearchResult.DataBind();

            ComponentShow(true);
            lbCurrentPage.Text = (pageIndex + 1).ToString();
        }

        /// <summary>
        /// Search data by conditions from DB and bind the result to the girdview to show.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchByConditions(object sender, EventArgs e)
        {
            ViewState["pageIndex"] = 0;
            QueryDB(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString(), 0);
        }

        /// <summary>
        /// Get the sortexpression and sortdirection,and call the QueryDB(...) method to obtain data sorted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVSorting(object sender, GridViewSortEventArgs e)
        { 
            string sortExpression = e.SortExpression.ToString();
            string sortDirection = ViewState["sortDirection"].ToString();
            if (sortDirection == "ASC")
            {
                sortDirection = "DESC";
            }
            else
            {
                sortDirection = "ASC";
            }
            ViewState["sortExpression"] = sortExpression;
            ViewState["sortDirection"] = sortDirection;
            QueryDB(sortExpression, sortDirection, Convert.ToInt32(ViewState["pageIndex"]));
        }
  
        /// <summary>
        ///  Call the QueryDB(...) method and obtain data of the previous page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bthPre_Click(object sender, EventArgs e)
        {
            int pageIndex = Convert.ToInt32(ViewState["pageIndex"]);
            if (pageIndex > 0)
            {
                pageIndex = pageIndex - 1;
                ViewState["pageIndex"] = pageIndex;
                QueryDB(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString(), pageIndex);
            }
        }

        /// <summary>
        ///  Call the QueryDB(...) method and obtain data of the next page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int pageIndex = Convert.ToInt32(ViewState["pageIndex"]);
            int pageCount = Convert.ToInt32(ViewState["pageCount"]);
            if (pageIndex < pageCount - 1)
            {
                pageIndex = pageIndex + 1;
                ViewState["pageIndex"] = pageIndex;
                QueryDB(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString(), pageIndex);
            }
        }
        
        /// <summary>
        ///  Call the QueryDB(...) method and obtain data of the first page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            ViewState["pageIndex"] = 0;
            QueryDB(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString(), 0);
        }

        /// <summary>
        /// Call the QueryDB(...) method and obtain data of the last page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLast_Click(object sender, EventArgs e)
        {
            int pageCount = Convert.ToInt32(ViewState["pageCount"]);
            ViewState["pageIndex"] = pageCount - 1;
            QueryDB(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString(), pageCount - 1);
        }

        /// <summary>
        /// Show or not show page related components.
        /// </summary>
        /// <param name="trueOrFalse"></param>
        public void ComponentShow(bool boolValue)
        {
            lbCurrentPage.Visible = boolValue;
            btnFirst.Visible = boolValue;
            btnLast.Visible = boolValue;
            btnNext.Visible = boolValue;
            btnPre.Visible = boolValue;
        }
    }
}