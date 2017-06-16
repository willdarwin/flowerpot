using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public class UpdateOrderDetailsPresenter : Presenter<IUpdateOrderDetailsView>
    {
        private ITTAOrdersController _controller;

        /// <summary>
        /// Create a new controller
        /// </summary>
        /// <param name="controller"></param>
        public UpdateOrderDetailsPresenter([CreateNew] ITTAOrdersController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Get all list of orderdetails  --by Eric
        /// </summary>
        /// <returns></returns>
        public List<OrderDetailsBE> GetAllOrderDetails()
        {
            return _controller.GetAllOrderDetails();
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
        /// Selects all product.  --by Will
        /// </summary>
        /// <returns></returns>
        public List<ProductBE> SelectAllProduct()
        {
            return _controller.SelectAllProduct();
        }

        /// <summary>
        /// Gets the product by id.  --by Will
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ProductBE GetProductById()
        {
            return _controller.GetProductById(View.ProductId);
        }
        
    }
}




