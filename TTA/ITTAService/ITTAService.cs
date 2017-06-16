using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TTA.Model;

namespace TTA.IService
{
    [ServiceContract]
    public interface ITTAService
    {
        /// <summary>
        /// Deletes the customer. --By Robin
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest request);

        /// <summary>
        /// Gets all addresses.  --By Robin
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetAllAddressesResponse GetAllAddresses(GetAllAddressesRequest request);

        /// <summary>
        /// Gets all customers.  --By Robin
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetAllCustomersResponse GetAllCustomers(GetAllCustomersRequest request);

        /// <summary>
        /// Gets the customer by id.  --By Robin
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        GetCustomerByIdResponse GetCustomerById(GetCustomerByIdRequest request);

        /// <summary>
        /// Inserts the customer.  --By Robin
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        InsertCustomerResponse InsertCustomer(InsertCustomerRequest request);

        /// <summary>
        /// Updates the customer.  --By Robin
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request);

        /// <summary>
        /// Deletes the order.  --Sunny
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        DeleteOrderResponse DeleteOrder(DeleteOrderRequest request);

        /// <summary>
        /// Closes the order.  --Sunny
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        CloseOrderResponse CloseOrder(CloseOrderRequest request);

        /// <summary>
        /// Gets the orders by condition.  --Sunny
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        GetOrdersbyConditionResponse GetOrdersbyCondition(GetOrdersbyConditionRequst request);

        /// <summary>
        /// Update orderstatus to open.  --Eric
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        OpenOrderResponse OpenOrder (OpenOrderRequest request);

        /// <summary>
        /// Gets the product by id.  --By Will
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        [OperationContract]
        GetProductByIdResponse GetProductById(GetProductByIdRequest request);

        /// <summary>
        /// Inserts the product.  --By Will
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        [OperationContract]
        InsertProductResponse InsertProduct(InsertProductRequest request);

        /// <summary>
        /// Updates the product.  --By Will
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        [OperationContract]
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);

        /// <summary>
        /// Deletes the product.  --By Will
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        [OperationContract]
        DeleteProductResponse DeleteProduct(DeleteProductRequst request);

        /// <summary>
        /// Selects all product.  --By Will
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        SelectAllProductResponse SelectAllProduct(SelectAllProductRequest request);

        /// <summary>
        /// Selects all category. --By Will
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        SelectAllCategoryResponse SelectAllCategory(SelectAllCategoryRequest request);

        /// <summary>
        /// Select all orderdetails -- By Eric
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetAllOrderDetailsResponse GetAllOrderDetails(GetAllOrderDetailsRequest request);

        /// <summary>
        /// Select all orderdetails by orderid  -- By Eric
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        GetOrderDetailsByOrderIdResponse GetOrderDetailsByOrderId(GetOrderDetailsByOrderIdRequest request);

        /// <summary>
        /// Insert orderdetails   -- By Eric
        /// </summary>
        /// <param name="orderDetailsBE"></param>
        [OperationContract]
        InsertOrderDetailsResponse InsertOrderDetails(InsertOrderDetailsRequest request);

        /// <summary>
        /// Insert order   -- By Eric
        /// </summary>
        /// <param name="request"></param>
        [OperationContract]
        InsertOrderResponse InsertOrder(InsertOrderRequest request);

        /// <summary>
        /// update orderdetails by orderdetailsid  -- By Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>

        [OperationContract]
        UpdateOrderDetailsResponse UpdateOrderDetails(UpdateOrderDetailsRequest request);

        /// <summary>
        /// update orderdetails by orderdetailsid  -- By Eric
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        CloseOrderDetailsResponse CloseOrderDetails(CloseOrderDetailsRequest request);

        /// <summary>
        /// delete orderdetails by orderdetailsid  -- By Eric
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        DeleteOrderDetailsResponse DeleteOrderDetails(DeleteOrderDetailsRequest request);

        /// <summary>
        /// Search order results by conditions. --By Lily
        /// </summary>
        /// <param name="request">The searchbyconditions request.</param>
        /// <returns></returns>
        [OperationContract]
        SearchByConditionsResponse SearchByConditions(SearchByConditionsRequest searchByConditionsRequest);

        /// <summary>
        /// Counts the order details by product id. --By Will
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [OperationContract]
        CountOrderDetailsByProductIdResponse CountOrderDetailsByProductId(CountOrderDetailsByProductIdRequest request);
    }
}
