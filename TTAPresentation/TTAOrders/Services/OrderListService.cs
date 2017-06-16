using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTAPresentation.TTAOrders.Services
{
    public class OrderListService : IOrderListService
    {
        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteOrder(int id) 
        {
            Proxy proxy = new Proxy();
            return proxy.DeleteOrder(id);
        }

        /// <summary>
        /// Closes the order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CloseOrder(int id) 
        {
            Proxy proxy = new Proxy();
            return proxy.CloseOrder(id);
        }

        /// <summary>
        /// Gets the ordersby condition.
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<OrderBE> GetOrdersbyCondition(string customerName, string startDate, string endDate) 
        {
            Proxy proxy = new Proxy();
            return proxy.GetOrdersbyCondition(customerName, startDate, endDate);
        }
    }
}
