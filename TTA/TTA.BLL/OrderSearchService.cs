using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTA.Model;
using TTA.DataEntity;
using TTA.DataManager;
using TTA.DataManagertor;


namespace TTA.BLL
{
    public class OrderSearchService
    {
        /// <summary>
        /// Search order information according to conditions and return an OrderSearchResultBE type list.
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="oper"></param>
        /// <param name="orderDate"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowCount)
        {
            OrderSearchManager orderSearchManager = new OrderSearchManager();
            List<OrderSearchResultBE> searchResultBEList = new List<OrderSearchResultBE>();

            searchResultBEList = orderSearchManager.GetOrderSearchResults(orderSearchParameterBE.CustomerName,
                                                                          orderSearchParameterBE.StartDate,
                                                                          orderSearchParameterBE.EndDate,
                                                                          orderSearchParameterBE.ProductName,
                                                                          orderSearchParameterBE.SortExpression,
                                                                          orderSearchParameterBE.SortDirection,
                                                                          orderSearchParameterBE.PageStart,
                                                                          orderSearchParameterBE.PageEnd,
                                                                          out rowCount);
            return searchResultBEList;
        }     
    }
}
