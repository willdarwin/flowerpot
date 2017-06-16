using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TTA.Model;
using TTA.DataManager;
using TTA.DataEntity;

namespace TTA.BLL
{
    public class OrderDetailsService
    {
        /// <summary>
        /// Obtain list of all the orderdetails 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetailsBE> GetAllOrderDetails()
        {
            List<OrderDetailsBE> OrderDetailsList = new OrderDetailsManager().GetAllOrderDetails();
            return OrderDetailsList;
        }

        /// <summary>
        /// Obtain list of orderdetails by its corresponding orderdetailsid
        /// </summary>
        /// <param name="orderId">A parameter from orderlist webform details button</param>
        /// <returns></returns>
        public List<OrderDetailsBE> GetOrderDetailsByOrderId(int orderId)
        {
            List<OrderDetailsBE> OrderDetailsList = new OrderDetailsManager().GetOrderDetailsByOrderId(orderId);
            return OrderDetailsList;
        }

        /// <summary>
        /// Insert a piece of orderdetails record according to user's ordering time and orderid
        /// </summary>
        /// <param name="orderDetailsBE"></param>
        public bool InsertOrderDetails(OrderDetailsBE orderDetailsBE)
        {
            return new OrderDetailsManager().Insert(orderDetailsBE);
        }

        /// <summary>
        /// Insert a piece of order record according to customername and return its corresponding orderid
        /// </summary>
        /// <param name="odBE">A object generate when create order </param>
        /// <returns></returns>
        public OrderBE InsertOrder(OrderBE oBE)
        {
            return new OrderManager().Insert(oBE);
            //return new OrderDetailsManager().InsertOrder(oBE);
        }

        /// <summary>
        /// Update a piece of orderdetails record according to its corresponding orderdetailsid
        /// </summary>
        /// <param name="orderdetailsBE">A object edit template </param>
        public bool UpdateOrderDetails(OrderDetailsBE orderdetailsBE)
        {
            return new OrderDetailsManager().Update(orderdetailsBE);
        }

        /// <summary>
        /// update orderdetails status
        /// </summary>
        /// <param name="id">orderdetailsid</param>
        public bool CloseOrderDetails(OrderDetailsBE orderdetailsBE)
        {
            return new OrderDetailsManager().Close(orderdetailsBE);
        }

        /// <summary>
        /// delete a piece of orderdetails record according to its corresponding orderdetailsid
        /// </summary>
        /// <param name="id">orderdetailsid</param>
        public bool DeleteOrderDetails(int id)
        {
            return new OrderDetailsManager().Delete(id);
        }

        /// <summary>
        /// Closes the order details by order ID. --sunny
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <returns></returns>
        public bool CloseOrderDetailsByOrderID(int orderId) 
        {
            List<OrderDetailsBE> list = GetOrderDetailsByOrderId(orderId);
            bool result = false;
            bool deleteResult = true;
            foreach (OrderDetailsBE orderDetail in list) 
            {
                deleteResult = deleteResult && (CloseOrderDetails(orderDetail));
            }
            if (deleteResult == true) 
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// get orderBE by orderid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderBE GetById(int id)
        {
            return new OrderManager().GetById(id);
        }

        /// <summary>
        /// update orderBE by orderid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Update(OrderBE order)
        {
            return new OrderManager().Update(order);
        }
    }
}
