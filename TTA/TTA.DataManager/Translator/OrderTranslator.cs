using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManager
{
    public class OrderTranslator
    {
        /// <summary>
        /// Translates Order into OrderBE.
        /// </summary>
        /// <param name="order"> order data entity.</param>
        /// <returns></returns>
        public OrderBE Translate(Order order)
        {
            if (order != null)
            {
                OrderBE orderBE = new OrderBE()
                {
                    OrderId = order.OrderId,
                    CreateTime = order.CreatedDate,
                    CustomerId = order.CustomerId,
                    OrderStatusId = order.StatusId,
                    Customer = new CustomerBE(),
                    OrderStatus = new OrderStatusBE()
                };

                if (order.Customer != null)
                {
                    CustomerTranslator customerTranslator = new CustomerTranslator();
                    orderBE.Customer = customerTranslator.Translate(order.Customer);
                }
                if (order.OrderStatus != null)
                {
                    orderBE.OrderStatus.OrderStatusId = order.OrderStatus.StatusId;
                    orderBE.OrderStatus.StatusName = order.OrderStatus.StatusName;
                    if (order.StatusId == 1) { orderBE.OrderCheckBoxFlag = true; }
                }
                return orderBE;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Translates orderBE into order.
        /// </summary>
        /// <param name="orderBE">The order BE.</param>
        /// <returns></returns>
        public Order Translate(OrderBE orderBE)
        {
            if (orderBE != null)
            {
                Order order = new Order()
                {
                    OrderId = orderBE.OrderId,
                    CreatedDate = orderBE.CreateTime,
                    StatusId = orderBE.OrderStatus.OrderStatusId,
                    CustomerId = orderBE.Customer.CustomerId,
                };
                return order;
            }
            else
            {
                return null;
            }
        }
    }
}
