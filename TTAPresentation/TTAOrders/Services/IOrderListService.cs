using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Services
{
    public interface IOrderListService
    {
        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <returns></returns>
        bool DeleteOrder(int id);

        /// <summary>
        /// Closes the order.
        /// </summary>
        /// <returns></returns>
        bool CloseOrder(int id);

        /// <summary>
        /// Gets the ordersby condition.
        /// </summary>
        /// <returns></returns>
        List<OrderBE> GetOrdersbyCondition(string customerName, string startDate, string endDate);
    }
}
