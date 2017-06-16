using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public class CreateOrderDetailsPresenter : Presenter<ICreateOrderDetailsView>
    {
        private ITTAOrdersController _controller;
        public CreateOrderDetailsPresenter([CreateNew] ITTAOrdersController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Get all list of orderdetails by orderid  --by Eric
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns> List<OrderDetailsBE>  </OrderDetailsBE> </returns>
        public List<OrderDetailsBE> GetOrderDetailsByOrderId()
        {
            return _controller.GetOrderDetailsByOrderId(View.OrderId);
        }

        /// <summary>
        /// Insert a piece of order and return the orderid  --by Eric
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Inserted order </returns>
        public OrderBE InsertOrder()
        {
            OrderBE order = new OrderBE()
            {
                CreateTime = DateTime.Now,
                CustomerId = int.Parse(View.CustomerName),
                OrderStatusId = 1,
                Customer = new CustomerBE()
                {
                    CustomerId = int.Parse(View.CustomerName),
                    Address = new AddressBE()
                    {
                        AddressId = 1
                    }
                },
                OrderStatus = new OrderStatusBE()
                {
                    OrderStatusId = 1
                }
            };
            return _controller.InsertOrder(order);
        }

        /// <summary>
        /// insert a piece of orderdetails by orderid   --by Eric
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public bool InsertOrderDetails()
        {
            OrderDetailsBE orderdetails = new OrderDetailsBE()
            {
                OrderId = View.OrderId,
                ProductId = 1,
                Quantity = 0,
                TotalPrice = 0
            };
            return _controller.InsertOrderDetails(orderdetails);
        }

        /// <summary>
        /// Update a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool CloseOrderDetails()
        {
            OrderDetailsBE orderdetails = new OrderDetailsBE()
            {
                OrderDetailId = View.OrderDetailsId,
                OrderId = View.OrderId,
                ProductId = View.ProductId,
                Quantity = View.Quantity,
                TotalPrice = View.TotalPrice
            };
            return _controller.CloseOrderDetails(orderdetails);
        }

        /// <summary>
        /// Delete a piece of orderdetails through orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailId"></param>
        /// <returns>IsDelete </returns>
        public bool DeleteOrderDetails()
        {
            OrderDetailsBE orderdetails = new OrderDetailsBE()
            {
                OrderDetailId = View.OrderDetailsId,
                OrderId = View.OrderId,
                ProductId = View.ProductId,
                Quantity = View.Quantity,
                TotalPrice = View.TotalPrice
            };
            return _controller.DeleteOrderDetails(orderdetails);
        }

        /// <summary>
        /// Update a piece of orderdetails by orderdetailsid   --by Eric
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns>IsUpdate </returns>
        public bool UpdateOrderDetails()
        {
            OrderDetailsBE orderdetails = new OrderDetailsBE()
            {
                OrderDetailId = View.OrderDetailsId,
                OrderId = View.OrderId,
                ProductId = View.ProductId,
                Quantity = View.Quantity,
                TotalPrice = View.TotalPrice
            };
            return _controller.UpdateOrderDetails(orderdetails);
        }

        /// <summary>
        /// Gets all customers.  --Robin
        /// </summary>
        /// <returns></returns>
        public List<CustomerBE> GetAllCustomers()
        {
            return _controller.GetAllCustomers();
        }

        /// <summary>
        /// Selects all product.--by Will
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            return _controller.SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.--by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById()
        {
            return _controller.GetProductById(View.ProductId);
        }

        /// <summary>
        /// Open order.  --Eric
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool OpenOrder()
        {
            return _controller.OpenOrder(View.OrderId);
        }
    }
}




