using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.ServiceProxy;

namespace TTAPresentation.TTAOrders.Services
{
     public class OrderDetailsService : IOrderDetailsService
    {
        /// <summary>
        /// Get all list of orderdetails  --by Eric
        /// </summary>
        /// <returns></returns>
        public List<OrderDetailsBE> GetAllOrderDetails()
        {
            return new Proxy().GetAllOrderDetails();
        }

        /// <summary>
        /// Get all list of orderdetails by orderid  --by Eric
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns> List<OrderDetailsBE>  </OrderDetailsBE> </returns>
        public List<OrderDetailsBE> GetOrderDetailsByOrderId(int orderid)
        {
            return new Proxy().GetOrderDetailsByOrderId(orderid);
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool CloseOrderDetails(OrderDetailsBE orderdetails)
        {
            return new Proxy().CloseOrderDetails(orderdetails);
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool DeleteOrderDetails(OrderDetailsBE orderdetails)
        {
            return new Proxy().DeleteOrderDetails(orderdetails);
        }

        /// <summary>
        /// Update a piece of orderdetails by orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns>IsUpdate </returns>
        public bool UpdateOrderDetails(OrderDetailsBE orderdetails)
        {
            return new Proxy().UpdateOrderDetails(orderdetails);
        }

        /// <summary>
        /// Insert a piece of order and return the orderid  --by Eric
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Inserted order </returns>
        public OrderBE InsertOrder(OrderBE order)
        {
            return new Proxy().InsertOrder(order);
        }

        /// <summary>
        /// insert a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public bool InsertOrderDetails(OrderDetailsBE orderdetails)
        {
            return new Proxy().InsertOrderDetails(orderdetails);
        }

        /// <summary>
        /// Selects all product.--by Will
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            return new Proxy().SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById(int id)
        {
            return new Proxy().GetProductById(id);
        }

        /// <summary>
        /// Gets all customers.  --Robin
        /// </summary>
        /// <returns></returns>
        public List<CustomerBE> GetAllCustomers()
        {
            return new Proxy().GetAllCustomers();
        }

        /// <summary>
        /// Gets the customer by id.  --Robin
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public CustomerBE GetCustomerById(int id)
        {
            return new Proxy().GetCustomerById(id); 
        }

        /// <summary>
        /// Open order.  --Eric
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool OpenOrder(int id)
        {
            return new Proxy().OpenOrder(id);
        }
    }
}
