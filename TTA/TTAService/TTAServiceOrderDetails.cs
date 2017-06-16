using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TTA.BLL;
using TTA.Model;
using TTA.IService;
using System.Transactions;

namespace TTA.Service
{
    public partial class TTAService : ITTAService
    {

        /// <summary>
        /// Select List of all the OrderDetails
        /// </summary>
        /// <returns>List of OrderDetails </returns>
        public GetAllOrderDetailsResponse GetAllOrderDetails(GetAllOrderDetailsRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            GetAllOrderDetailsResponse response = new GetAllOrderDetailsResponse();
            try
            {
                response.OrderDetailsBEList = service.GetAllOrderDetails();
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Select List of all the OrderDetails by orderid
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List of OrderDetails</returns>
        public GetOrderDetailsByOrderIdResponse GetOrderDetailsByOrderId(GetOrderDetailsByOrderIdRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            GetOrderDetailsByOrderIdResponse response = new GetOrderDetailsByOrderIdResponse();
            try
            {
                response.OrderDetailsBEList = service.GetOrderDetailsByOrderId(request.Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsFailed = true;
                throw new Exception(ex.Message);
            }
            return response;
        }

        /// <summary>
        /// Insert orderdetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public InsertOrderDetailsResponse InsertOrderDetails(InsertOrderDetailsRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            InsertOrderDetailsResponse response = new InsertOrderDetailsResponse();
            try
            {
                response.IsFailed = !(service.InsertOrderDetails(request.OrderDetailsBE));
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }


        /// <summary>
        /// Insert orderdetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public InsertOrderResponse InsertOrder(InsertOrderRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            InsertOrderResponse response = new InsertOrderResponse();
            try
            {
                response.OrderBE = service.InsertOrder(request.OrderBE);
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.IsFailed = true;
            }
            return response;
        }

        /// <summary>
        /// Update orderdetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateOrderDetailsResponse UpdateOrderDetails(UpdateOrderDetailsRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            UpdateOrderDetailsResponse response = new UpdateOrderDetailsResponse();
            try
            {
                response.IsFailed = !(service.UpdateOrderDetails(request.OrderDetailsBE));
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Delete orderdetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CloseOrderDetailsResponse CloseOrderDetails(CloseOrderDetailsRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            OrderService orderService = new OrderService();
            CloseOrderDetailsResponse response = new CloseOrderDetailsResponse();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    response.IsFailed = !(service.CloseOrderDetails(request.OrderDetailsBE));
                    if (service.GetOrderDetailsByOrderId(request.OrderDetailsBE.OrderId).Count == 0)
                    {
                        orderService.DeleteOrder(request.OrderDetailsBE.OrderId);
                    }
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }        
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Delete orderdetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteOrderDetailsResponse DeleteOrderDetails(DeleteOrderDetailsRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            DeleteOrderDetailsResponse response = new DeleteOrderDetailsResponse();
            OrderService orderService = new OrderService();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    response.IsFailed = !(service.DeleteOrderDetails(request.OrderDetails.OrderDetailId));
                    if (service.GetOrderDetailsByOrderId(request.OrderDetails.OrderId).Count == 0)
                    {
                        orderService.DeleteOrder(request.OrderDetails.OrderId);
                    }
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }             
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public OpenOrderResponse OpenOrder (OpenOrderRequest request)
        {
            OrderDetailsService service = new OrderDetailsService();
            OpenOrderResponse response = new OpenOrderResponse();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    request.Order = service.GetById(request.OrderId);
                    request.Order.OrderStatusId = 1;
                    request.Order.OrderStatus.OrderStatusId = 1;
                    request.Order.OrderStatus.StatusName = "Open";
                    if (request.Order!= null)
                    {
                        service.Update(request.Order);
                    }
                    // The Complete method commits the transaction. If an exception has been thrown,
                    // Complete is not  called and the transaction is rolled back.
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
