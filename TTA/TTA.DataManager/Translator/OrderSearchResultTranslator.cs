using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManagertor
{
    public class OrderSearchResultTranslator
    {
        /// <summary>
        /// Translate an OrderSearchResult object to OrderSearchResultBE type.
        /// </summary>
        /// <param name="searchResultDE"></param>
        /// <returns></returns>
        public OrderSearchResultBE TranslateToBE(OrderSearchResult searchResultDE)
        {
            if (searchResultDE != null)
            {
                OrderSearchResultBE searchResultBE = new OrderSearchResultBE()
                {
                    OrderId = searchResultDE.OrderId,
                    CreatedDate = searchResultDE.CreatedDate,
                    CustomerName = searchResultDE.CustomerName,
                    ProductName = searchResultDE.ProductName,
                    TotalPrice = searchResultDE.TotalPrice
                };
                return searchResultBE;
            }
            else
            {
                return null;
            }  
        }

        /// <summary>
        /// Translate a list<OrderSearchResult> to list<OrderSearchResultBE> type.
        /// </summary>
        /// <param name="searchResultDEList"></param>
        /// <returns></returns>
        public List<OrderSearchResultBE> TranslateToBEList(List<OrderSearchResult> searchResultDEList)
        {
            List<OrderSearchResultBE> searchResultBEList = new List<OrderSearchResultBE>();
            OrderSearchResultBE searchResultBE = new OrderSearchResultBE();
            foreach (OrderSearchResult searchResultDE in searchResultDEList)
            {
                searchResultBE = this.TranslateToBE(searchResultDE);
                searchResultBEList.Add(searchResultBE);
            }
            return searchResultBEList;
        }
    }
}
