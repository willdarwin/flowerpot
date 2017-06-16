using System;
using System.Collections.Generic;
using TTA.Model;
using TTAPresentation.TTAOrders.Services;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace TTAPresentation.TTAOrders
{
    public class TTAOrdersController : ITTAOrdersController
    {
        #region Properties
        /// <summary>
        /// Sets the order details service.
        /// </summary>
        /// <value>
        /// The order details service.
        /// </value>        
        private IOrderDetailsService _orderdetailsService;
        [ServiceDependency]
        public IOrderDetailsService OrderDetailsService
        {
            set { _orderdetailsService = value; }
        }

        /// <summary>
        /// Using a registered service 
        /// </summary>        
        private IOrderListService _orderListService;
        [ServiceDependency]
        public IOrderListService OrderListService
        {
            set { _orderListService = value; }
        }

        /// <summary>
        /// Sets the order search service.
        /// </summary>
        /// <value>
        /// The order search service.
        /// </value>
        private IOrderSearchService _orderSearchService;
        [ServiceDependency]
        public IOrderSearchService OrderSearchService
        {
            set { _orderSearchService = value; }
        }
        #endregion

        #region Public method
        /// <summary>
        /// Get all list of orderdetails  --by Eric
        /// </summary>
        /// <returns></returns>
        public virtual List<OrderDetailsBE> GetAllOrderDetails()
        {
            return _orderdetailsService.GetAllOrderDetails();
        }

        /// <summary>
        /// Get all list of orderdetails by orderid  --by Eric
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns> List<OrderDetailsBE>  </OrderDetailsBE> </returns>
        public virtual List<OrderDetailsBE> GetOrderDetailsByOrderId(int id)
        {
            return _orderdetailsService.GetOrderDetailsByOrderId(id);
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public virtual bool DeleteOrderDetails(OrderDetailsBE orderdetails)
        {
            return _orderdetailsService.DeleteOrderDetails(orderdetails);
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public virtual bool CloseOrderDetails(OrderDetailsBE orderdetails)
        {
            return _orderdetailsService.CloseOrderDetails(orderdetails);
        }

        /// <summary>
        /// Update a piece of orderdetails by orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns>IsUpdate </returns>
        public virtual bool UpdateOrderDetails(OrderDetailsBE orderdetails)
        {
            return _orderdetailsService.UpdateOrderDetails(orderdetails);
        }

        /// <summary>
        /// Insert a piece of order and return the orderid  --by Eric
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Inserted order </returns>
        public virtual OrderBE InsertOrder(OrderBE order)
        {
            return _orderdetailsService.InsertOrder(order);
        }

        /// <summary>
        /// insert a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public virtual bool InsertOrderDetails(OrderDetailsBE orderdetails)
        {
            return _orderdetailsService.InsertOrderDetails(orderdetails);
        }

        /// <summary>
        /// Open order.  --Eric
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool OpenOrder(int id)
        {
            return _orderdetailsService.OpenOrder(id);
        }
        
        /// <summary>
        /// Deletes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual bool DeleteOrder(int id)
        {
            return _orderListService.DeleteOrder(id);
        }

        /// <summary>
        /// Closes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual bool CloseOrder(int id) 
        {
            return _orderListService.CloseOrder(id);
        }

        /// <summary>
        /// Gets the ordersby condition. --sunny
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public virtual List<OrderBE> GetOrdersbyCondition(string customerName, string startDate, string endDate)
        {
            return _orderListService.GetOrdersbyCondition(customerName, startDate, endDate);
        }

        /// <summary>
        /// Get order details and product details by conditions. --Lily
        /// </summary>
        /// <param name="orderSearchParameterBE"></param>
        /// <param name="rowConut">An output parameter, return the rowcount of search results.</param>
        /// <returns></returns>
        public virtual List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowConut)
        {
            return _orderSearchService.SearchByConditions(orderSearchParameterBE, out rowConut);
        }


        /// <summary>
        /// Selects all product.--by Will
        /// </summary>
        /// <returns></returns>
        public virtual List<ProductBE> SelectAllProduct()
        {
            return _orderdetailsService.SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual ProductBE GetProductById(int id)
        {
            return _orderdetailsService.GetProductById(id);
        }

        /// <summary>
        /// Gets all customers.  --Robin
        /// </summary>
        /// <returns></returns>
        public virtual List<CustomerBE> GetAllCustomers()
        {
            return _orderdetailsService.GetAllCustomers();
        }

        /// <summary>
        /// Gets the customer by id.  --Robin
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual CustomerBE GetCustomerById(int id)
        {
            return _orderdetailsService.GetCustomerById(id);
        }
        #endregion
    }
}
