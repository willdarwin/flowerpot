using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TTA.Model;
using TTA.IService;
using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace TTA.ServiceProxy
{
    public class Proxy
    {
        #region private field
        private static volatile ChannelFactory<ITTAService> myChannelFactory;
        private static object syncRoot = new Object();
        #endregion

        /// <summary>
        /// Create a singleton of channelfactory
        /// </summary>
        public static ChannelFactory<ITTAService> MyChannelFactory
        {
            get
            {
                if (myChannelFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (myChannelFactory == null)
                            myChannelFactory = new ChannelFactory<ITTAService>("ITTAService");
                    }
                }
                return myChannelFactory;
            }
        }

        /// <summary>
        /// Gets all addresses.  --Robin
        /// </summary>
        /// <returns></returns>
        public List<AddressBE> GetAllAddresses()
        {
            GetAllAddressesRequest request = new GetAllAddressesRequest();
            GetAllAddressesResponse response = null;
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                response = MyChannelFactory.CreateChannel().GetAllAddresses(request);
            }
            catch (System.Exception ex)
            {
                log.Error("error", ex);
                log.Fatal("fatal", ex);
                throw new Exception("We have a error！ Maybe the endpoint is not correct");
            }
            if (response.IsFailed)
            {
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！");
            }
            return response.AddressesList;
        }

        /// <summary>
        /// Gets the customer by id.  --Robin
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public CustomerBE GetCustomerById(int id)
        {
            GetCustomerByIdRequest request = new GetCustomerByIdRequest();
            request.Id = id;
            GetCustomerByIdResponse response = MyChannelFactory.CreateChannel().GetCustomerById(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！");
            }
            return response.MyCustomer;
        }

        /// <summary>
        /// Updates the customer.  --Robin
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        public bool UpdateCustomer(CustomerBE customerBE)
        {
            UpdateCustomerRequest request = new UpdateCustomerRequest();
            request.MyCustomer = customerBE;
            UpdateCustomerResponse response = MyChannelFactory.CreateChannel().UpdateCustomer(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！" );
            }
            return true;
        }

        /// <summary>
        /// Inserts the customer.  --Robin
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        public bool InsertCustomer(CustomerBE customerBE)
        {
            InsertCustomerRequest request = new InsertCustomerRequest();
            request.MyCustomer = customerBE;
            InsertCustomerResponse response = MyChannelFactory.CreateChannel().InsertCustomer(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！");
            }
            return true;
        }

        /// <summary>
        /// Gets all customers.  --Robin
        /// </summary>
        /// <returns></returns>
        public List<CustomerBE> GetAllCustomers()
        {
            GetAllCustomersRequest request = new GetAllCustomersRequest();
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            GetAllCustomersResponse response = null;
            try
            {
            	response = MyChannelFactory.CreateChannel().GetAllCustomers(request);
            }
            catch (System.Exception ex)
            {
                log.Error("error", ex);
                log.Fatal("fatal", ex);
                throw new Exception("We have a error！ Maybe the endpoint is not correct");
            }
            if (response.IsFailed)
            {
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！");
            }
            return response.CustomersList;
        }

        /// <summary>
        /// Deletes the customer.  --Robin
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        {
            DeleteCustomerRequest request = new DeleteCustomerRequest();
            request.Id = id;
            DeleteCustomerResponse response = MyChannelFactory.CreateChannel().DeleteCustomer(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw new Exception("We have a error！");
            }
            return true;
        }

        /// <summary>
        /// Deletes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteOrder(int id)
        {
            DeleteOrderRequest request = new DeleteOrderRequest()
            {
                OrderId = id
            };
            DeleteOrderResponse response = MyChannelFactory.CreateChannel().DeleteOrder(request);
            if (response.IsFailed == true)
            {
                response = myChannelFactory.CreateChannel().DeleteOrder(request);
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return !response.IsFailed;
        }

        /// <summary>
        /// Closes the order. --sunny
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool CloseOrder(int id)
        {
            CloseOrderRequest request = new CloseOrderRequest()
            {
                OrderId = id
            };
            CloseOrderResponse response = MyChannelFactory.CreateChannel().CloseOrder(request);
            if (response.IsFailed == true)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }

            return !response.IsFailed;
        }

        /// <summary>
        /// Gets the ordersby condition. --sunny
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<OrderBE> GetOrdersbyCondition(string customerName, string startDate, string endDate)
        {
            GetOrdersbyConditionRequst request = new GetOrdersbyConditionRequst()
            {
                OrderSearchCondition = new OrderSearchParameterBE()
                {
                    CustomerName = customerName,
                    StartDate = startDate,
                    EndDate = endDate
                }
            };
            GetOrdersbyConditionResponse response = null;
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                response = MyChannelFactory.CreateChannel().GetOrdersbyCondition(request);

            }
            catch (System.Exception ex)
            {
                log.Error("error", ex);
                log.Fatal("fatal", ex);
                throw new Exception("We have a error！ Maybe the remote service is down");
            }
            if (response.IsFailed == true)
            {
               
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.OrderList;
        }

        /// <summary>
        /// Get order details search result by conditions. --Lily
        /// </summary>
        /// <param name="orderSearchParameterBE"></param>
        /// <param name="rowConut">An output parameter, return the rowcount of search results.</param>
        /// <returns></returns>
        public List<OrderSearchResultBE> SearchByConditions(OrderSearchParameterBE orderSearchParameterBE, out int rowConut)
        {
            SearchByConditionsRequest request = new SearchByConditionsRequest()
            {
                OrderSearchConditions = orderSearchParameterBE
            };
            SearchByConditionsResponse response = MyChannelFactory.CreateChannel().SearchByConditions(request);
            rowConut = response.RowCount;

            if (response.IsFailed == true)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.OrderSearchResultBEList;
        }

        /// <summary>
        /// Get all list of orderdetails  --by Eric
        /// </summary>
        /// <returns></returns>
        public List<OrderDetailsBE> GetAllOrderDetails()
        {
            GetAllOrderDetailsRequest request = new GetAllOrderDetailsRequest();
            GetAllOrderDetailsResponse response = MyChannelFactory.CreateChannel().GetAllOrderDetails(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.OrderDetailsBEList;
        }

        /// <summary>
        /// Get all list of orderdetails by orderid  --by Eric
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns> List<OrderDetailsBE>  </OrderDetailsBE> </returns>
        public List<OrderDetailsBE> GetOrderDetailsByOrderId(int orderid)
        {
            GetOrderDetailsByOrderIdRequest request = new GetOrderDetailsByOrderIdRequest();
            request.Id = orderid;
            GetOrderDetailsByOrderIdResponse response = MyChannelFactory.CreateChannel().GetOrderDetailsByOrderId(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.OrderDetailsBEList;
        }

        /// <summary>
        /// Update a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool CloseOrderDetails(OrderDetailsBE orderdetails)
        {
            CloseOrderDetailsRequest request = new CloseOrderDetailsRequest();
            request.OrderDetailsBE = orderdetails;
            CloseOrderDetailsResponse response = MyChannelFactory.CreateChannel().CloseOrderDetails(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.IsFailed;
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool DeleteOrderDetails(OrderDetailsBE orderdetails)
        {

            DeleteOrderDetailsRequest request = new DeleteOrderDetailsRequest();
            request.OrderDetails = orderdetails;
            DeleteOrderDetailsResponse response = MyChannelFactory.CreateChannel().DeleteOrderDetails(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.IsFailed;
        }

        /// <summary>
        /// Update a piece of orderdetails by orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns>IsUpdate </returns>
        public bool UpdateOrderDetails(OrderDetailsBE orderdetails)
        {
            UpdateOrderDetailsRequest request = new UpdateOrderDetailsRequest();
            request.OrderDetailsBE = orderdetails;
            UpdateOrderDetailsResponse response = MyChannelFactory.CreateChannel().UpdateOrderDetails(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.IsFailed;
        }

        /// <summary>
        /// Insert a piece of order and return the orderid  --by Eric
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Inserted order </returns>
        public OrderBE InsertOrder(OrderBE order)
        {
            InsertOrderRequest request = new InsertOrderRequest();
            request.OrderBE = order;
            InsertOrderResponse response = MyChannelFactory.CreateChannel().InsertOrder(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.OrderBE;
        }

        /// <summary>
        /// insert a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public bool InsertOrderDetails(OrderDetailsBE orderdetails)
        {
            InsertOrderDetailsRequest request = new InsertOrderDetailsRequest();
            request.OrderDetailsBE = orderdetails;
            InsertOrderDetailsResponse response = MyChannelFactory.CreateChannel().InsertOrderDetails(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.IsFailed;
        }

        /// <summary>
        /// Selects all product.--by Will
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            SelectAllProductRequest request = new SelectAllProductRequest();
            SelectAllProductResponse response = MyChannelFactory.CreateChannel().SelectAllProduct(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.ProductList;
        }

        /// <summary>
        /// Gets the product by id.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById(int id)
        {
            GetProductByIdRequest request = new GetProductByIdRequest();
            request.Id = id;
            GetProductByIdResponse response = MyChannelFactory.CreateChannel().GetProductById(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.Product;
        }

        /// <summary>
        /// Inserts the product.--by Will
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool InsertProduct(ProductBE productBE)
        {
            InsertProductRequest request = new InsertProductRequest();
            request.Product = productBE;
            InsertProductResponse response = MyChannelFactory.CreateChannel().InsertProduct(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return !response.IsFailed;
        }

        /// <summary>
        /// Update a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public bool OpenOrder(int id)
        {
            OpenOrderRequest request = new OpenOrderRequest();
            request.OrderId = id;
            OpenOrderResponse response = MyChannelFactory.CreateChannel().OpenOrder(request);
            if (response != null)
            {
                if (response.IsFailed == true)
                {
                    ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error("error", new Exception(response.Message));
                    log.Fatal("fatal", new Exception(response.Message));
                    throw (new Exception(response.Message));
                }
            }
            return response.IsFailed;
        }

        /// <summary>
        /// Updates the product. --by Will
        /// </summary>
        /// <param name="productBE">The product BE.</param>
        /// <returns></returns>
        public bool UpdateProduct(ProductBE productBE)
        {
            UpdateProductRequest request = new UpdateProductRequest();
            request.product = productBE;
            UpdateProductResponse response = MyChannelFactory.CreateChannel().UpdateProduct(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return !response.IsFailed;
        }

        /// <summary>
        /// Deletes the product.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            DeleteProductRequst request = new DeleteProductRequst();
            request.ProductId = id;
            DeleteProductResponse response = MyChannelFactory.CreateChannel().DeleteProduct(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return !response.IsFailed;
        }

        /// <summary>
        /// Selects all category.--by Will
        /// </summary>
        /// <returns></returns>
        public List<CategoryBE> SelectAllCategory()
        {
            SelectAllCategoryRequest request = new SelectAllCategoryRequest();
            SelectAllCategoryResponse response = MyChannelFactory.CreateChannel().SelectAllCategory(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.CategoryList;
        }

        /// <summary>
        /// Counts the order details by product id. --Will
        /// </summary>
        /// <param name="productid">The productid.</param>
        /// <returns></returns>
        public int CountOrderDetailsByProductId(int productid)
        {
            CountOrderDetailsByProductIdRequest request = new CountOrderDetailsByProductIdRequest();
            request.Id = productid;
            CountOrderDetailsByProductIdResponse response = MyChannelFactory.CreateChannel().CountOrderDetailsByProductId(request);
            if (response.IsFailed)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", new Exception(response.Message));
                log.Fatal("fatal", new Exception(response.Message));
                throw (new Exception(response.Message));
            }
            return response.count;
        }

    }
}


