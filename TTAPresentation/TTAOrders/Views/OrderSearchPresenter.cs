using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public class OrderSearchPresenter : Presenter<IOrderSearchView>
    {
        #region Private var

        /// <summary>
        /// The TTAOrders Controller.
        /// </summary>
        private ITTAOrdersController _controller;

        /// <summary>
        /// The asc sort direction string.
        /// </summary>
        private const string SortDireASC = "ASC";

        /// <summary>
        /// The desc sort direction string.
        /// </summary>
        private const string SortDireDESC = "DESC";
        
        #endregion

        public OrderSearchPresenter([CreateNew] ITTAOrdersController controller)
        {
            _controller = controller;
        }

        #region Public methods
      
        /// <summary>
        /// Search result by conditions and get the current page.
        /// </summary>
        public List<OrderSearchResultBE> SearchByConditions()
        {
            int rowConut, pageCount, pageIndex, pageSize;
            pageIndex = View.CurrentPageIndex;
            pageSize = View.PageSize;
            OrderSearchParameterBE orderSearchParameterBE = new OrderSearchParameterBE()
            {
                CustomerName = View.CustomerName,
                StartDate = View.StartDate,
                EndDate = View.EndDate,
                ProductName = View.ProductName,
                SortExpression = View.SortExpression,
                SortDirection = View.SortDirection,
                PageStart = pageSize * pageIndex + 1,
                PageEnd = pageSize * (pageIndex + 1)
            };
            List<OrderSearchResultBE> OrderSearchResultList = _controller.SearchByConditions(orderSearchParameterBE, out rowConut);

            pageCount = (int)Math.Ceiling((double)rowConut / (double)View.PageSize);
            View.TotalPageCount = pageCount;

            List<string> pageList = new List<string>();
            pageList.Add("--");
            for (int i = 1; i <= pageCount; i ++)
            {
                pageList.Add(i.ToString());
            }
            View.PageList = pageList;
            return OrderSearchResultList;
        }
       
        /// <summary>
        /// Get the search result of first page.
        /// </summary>
        /// <returns>The search result of current page.</returns>
        public List<OrderSearchResultBE> ShowFirstPage()
        {
            View.CurrentPageIndex = 0;
            return SearchByConditions();
        }

        /// <summary>
        /// Get the search result of previous page.
        /// </summary>
        /// <returns>The search result of current page.</returns>
        public List<OrderSearchResultBE> ShowPrePage()
        {
            View.CurrentPageIndex --;
            return SearchByConditions();
        }

        /// <summary>
        /// Get the search result of next page.
        /// </summary>
        /// <returns>The search result of current page.</returns>
        public List<OrderSearchResultBE> ShowNextPage()
        {
            View.CurrentPageIndex ++;
            return SearchByConditions();
        }

        /// <summary>
        /// Get the search result of last page.
        /// </summary>
        /// <returns>The search result of current page.</returns>
        public List<OrderSearchResultBE> ShowLastPage()
        {
            View.CurrentPageIndex = View.TotalPageCount - 1;
            return SearchByConditions();
        }

        /// <summary>
        /// Get the sorted search result.
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public List<OrderSearchResultBE> Sorting(string sortExpression)
        {
            string sortDirection = View.SortDirection;
            if (sortDirection == SortDireASC)
            {
                sortDirection = SortDireDESC;
            }
            else
            {
                sortDirection = SortDireASC;
            }
            View.SortExpression = sortExpression;
            View.SortDirection = sortDirection;
            return SearchByConditions();
        }

        /// <summary>
        ///  Get the search result of the selected page.
        /// </summary>
        /// <returns>The search result of current page.</returns>
        public List<OrderSearchResultBE> ShowPageChanged()
        {
            if (View.SelectedPage != "")
            {
                int pageIndex = Convert.ToInt32(View.SelectedPage) - 1;
                View.CurrentPageIndex = pageIndex;
            }
            return SearchByConditions();
        }

        #endregion
    }
}




