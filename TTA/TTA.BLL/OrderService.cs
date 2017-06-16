using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTA.DataManager;

namespace TTA.BLL
{
    public class OrderService
    {
        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteOrder(int id)
        {
            OrderManager manager = new OrderManager();
            return manager.Delete(id);
        }

        /// <summary>
        /// Closes order by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Close(int id)
        {
            OrderManager manager = new OrderManager();
            return manager.Close(id);
        }

        /// <summary>
        /// Get order according to condition.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="startDate">The date.</param>
        /// <param name="endDate">The compare.</param>
        /// <returns></returns>
        public List<OrderBE> GetbyCondition(string customerName, string startDate, string endDate)
        {
            List<OrderBE> list = new List<OrderBE>();
            OrderManager manager = new OrderManager();
            
            List<OrderBE> orderList = manager.GetByCondition(customerName, startDate, endDate);

            return orderList;
        }
    }
}
