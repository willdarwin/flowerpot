using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTAPresentation.TTAOrders.Services
{
    public class OrderSearchService : IOrderSearchService
    {
        // <summary>
        /// Get order details and product details by conditions. --Lily
        /// </summary>
        /// <param name="orderSearchParameterBE"></param>
        /// <param name="rowConut">An output parameter, return the rowcount of search results.</param>
        /// <returns></returns>
        public List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowConut)
        {
            Proxy proxy = new Proxy();
            return proxy.SearchByConditions(orderSearchParameterBE, out rowConut);
        }
    }
}
