using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;
using TTA.DataManagertor;


namespace TTA.DataManager
{
    public partial class OrderSearchManager
    {
        /// <summary>
        /// Excute the procedure to obtain search results and return them in form of a List<OrderSearchResult> object.
        /// </summary>
        /// <param name="dbEntity"></param>
        /// <param name="customerName"></param>
        /// <param name="oper"></param>
        /// <param name="orderDate"></param>
        /// <param name="productName"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private List<OrderSearchResult> GetOrderSearchResults(TTAEntityContainer dbEntity,string customerName, string startDate, 
                                                            string endDate, string productName, string sortExpression,
                                                            string sortDirection, int pageStart, int pageEnd, out int rowCount)
        {
            DateTime sDate = new DateTime(1990, 1, 1);
            DateTime eDate = DateTime.Now;
            List<OrderSearchResult> orderSRDEList = new List<OrderSearchResult>();
            System.Data.Objects.ObjectParameter rowNum = new System.Data.Objects.ObjectParameter("RowNum", typeof(int));

            if (!string.IsNullOrEmpty(startDate))
            {
                sDate = Convert.ToDateTime(startDate);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                eDate = Convert.ToDateTime(endDate);
            }

            if (sDate > eDate)
            {
                DateTime dateTemp = new DateTime();
                dateTemp = sDate;
                sDate = eDate;
                eDate = dateTemp;
            }
            orderSRDEList = (from u in dbEntity.SearchResults(customerName, sDate, eDate, productName,
                                                              sortExpression, sortDirection, pageStart, pageEnd, rowNum)
                             select u).ToList<OrderSearchResult>();
            rowCount = (int)rowNum.Value;

            return orderSRDEList;
        }

        /// <summary>
        /// Call GetOrderSearchResults(...) method to obtain search results in form of a List<OrderSearchResult> object,
        /// and transform it to  List<OrderSearchResultBE> type.
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="oper"></param>
        /// <param name="orderDate"></param>
        /// <param name="productName"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortDirection"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<OrderSearchResultBE> GetOrderSearchResults(string customerName, string startDate, string endDate,
                                                            string productName, string sortExpression, string sortDirection,
                                                            int pageStart, int pageEnd, out int rowCount)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            List<OrderSearchResult> searchResultList = new List<OrderSearchResult>();

            searchResultList = this.GetOrderSearchResults(dbEntity, customerName, startDate, endDate, productName,
                                              sortExpression, sortDirection, pageStart, pageEnd, out rowCount);

            List<OrderSearchResultBE> searchResultBEList = new List<OrderSearchResultBE>();
            OrderSearchResultTranslator orderSearchResultTranslator = new OrderSearchResultTranslator();
            searchResultBEList = orderSearchResultTranslator.TranslateToBEList(searchResultList);

            return searchResultBEList;
        }
    }
}
