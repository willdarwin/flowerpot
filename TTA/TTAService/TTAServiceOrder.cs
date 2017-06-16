using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TTA.Model;
using TTA.BLL;
using TTA.IService;
using System.Transactions;

namespace TTA.Service
{
    public partial class TTAService : ITTAService
    {
        /// <summary>
        /// Delete order by request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DeleteOrderResponse DeleteOrder(DeleteOrderRequest request)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();
            OrderService service = new OrderService();
            OrderDetailsService orderDetailsService = new OrderDetailsService();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    bool result = service.DeleteOrder(request.OrderId);
                    bool deleteOrderDetailsResult = orderDetailsService.CloseOrderDetailsByOrderID(request.OrderId);
                    if (result && deleteOrderDetailsResult) 
                    {
                        scope.Complete();
                    }                    
                }
            }
            catch (TransactionAbortedException ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Closes order.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CloseOrderResponse CloseOrder(CloseOrderRequest request)
        {
            CloseOrderResponse response = new CloseOrderResponse();
            OrderService service = new OrderService();

            try
            {
                bool result = service.Close(request.OrderId);
                if (result == false)
                {
                    response.IsFailed = true;
                    response.Message = "Close Order failed.";
                }
                else
                {
                    response.IsFailed = false;
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
        /// Gets the ordersby codition.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetOrdersbyConditionResponse GetOrdersbyCondition(GetOrdersbyConditionRequst request)
        {
            GetOrdersbyConditionResponse response = new GetOrdersbyConditionResponse();
            OrderService service = new OrderService();

            try
            {
                response.OrderList = service.GetbyCondition(request.OrderSearchCondition.CustomerName, request.OrderSearchCondition.StartDate, request.OrderSearchCondition.EndDate);
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
