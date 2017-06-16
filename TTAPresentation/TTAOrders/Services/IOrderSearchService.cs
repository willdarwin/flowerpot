using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Services
{
    public interface IOrderSearchService
    {
        // <summary>
        /// Get order details and product details by conditions. --Lily
        /// </summary>
        /// <param name="orderSearchParameterBE"></param>
        /// <param name="rowConut">An output parameter, return the rowcount of search results.</param>
        /// <returns></returns>
        List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowConut);
    }
}
