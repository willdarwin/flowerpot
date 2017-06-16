using System;
using System.Collections.Generic;
using TTA.Model;

namespace TTAPresentation.TTAOrders
{
    public interface ITTAOrdersController
    {
        /// <summary>
        /// Deletes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool DeleteOrder(int id);

        /// <summary>
        /// Closes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool CloseOrder(int id);

        /// <summary>
        /// Gets the ordersby condition. --sunny
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        List<OrderBE> GetOrdersbyCondition(string customerName, string startDate, string endDate);

        /// <summary>
        /// Get all list of orderdetails  --by Eric
        /// </summary>
        /// <returns></returns>
        List<OrderDetailsBE> GetAllOrderDetails();

        /// <summary>
        /// Get all list of orderdetails by orderid  --by Eric
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns> List<OrderDetailsBE>  </OrderDetailsBE> </returns>
        List<OrderDetailsBE> GetOrderDetailsByOrderId(int orderid);

        /// <summary>
        /// Update a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        bool CloseOrderDetails(OrderDetailsBE orderdetails);

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        bool DeleteOrderDetails(OrderDetailsBE orderdetails);

        /// <summary>
        /// Update a piece of orderdetails by orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns>IsUpdate </returns>
        bool UpdateOrderDetails(OrderDetailsBE orderdetails);

        /// <summary>
        /// Insert a piece of order and return the orderid  --by Eric
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Inserted order </returns>
        OrderBE InsertOrder(OrderBE order);

        /// <summary>
        /// insert a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        bool InsertOrderDetails(OrderDetailsBE orderdetails);

        /// <summary>
        /// Open order.  --Eric
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool OpenOrder(int id);

        /// <summary>
        /// Selects all product.--by Will
        /// </summary>
        /// <returns></returns>
        List<ProductBE> SelectAllProduct();

        /// <summary>
        /// Gets the product by id.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        ProductBE GetProductById(int id);

        /// <summary>
        /// Gets all customers.  --Robin
        /// </summary>
        /// <returns></returns>
        List<CustomerBE> GetAllCustomers();

        /// <summary>
        /// Gets the customer by id.  --Robin
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        CustomerBE GetCustomerById(int id);

        /// <summary>
        /// Get order details and product details by conditions. --Lily
        /// </summary>
        /// <param name="orderSearchParameterBE"></param>
        /// <param name="rowConut">An output parameter, return the rowcount of search results.</param>
        /// <returns></returns>
        List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowConut);
    }
}
