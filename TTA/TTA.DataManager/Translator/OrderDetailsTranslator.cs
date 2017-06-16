using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using TTA.Model;


namespace TTA.DataManager
{
    public class OrderDetailsTranslator
    {
        /// <summary>
        /// translate OrderDetails type to OrderDetailsBE type
        /// </summary>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public OrderDetailsBE Translate(OrderDetails orderdetails)
        {
            if (orderdetails != null)
            {
                OrderDetailsBE orderdetailsBE = new OrderDetailsBE()
                {
                    OrderDetailId = orderdetails.OrderDetailId,
                    OrderId = orderdetails.OrderId,
                    ProductId = orderdetails.ProductId,
                    Quantity = orderdetails.Quantity,
                    TotalPrice = orderdetails.TotalPrice,
                    IsDeleted=orderdetails.IsDeleted,
                    Order = new OrderTranslator().Translate(orderdetails.Order),
                    Product = new ProductTranslator().Translate(orderdetails.Product)

                };
                if (orderdetails.Order != null)
                {
                    OrderTranslator orderTranslator = new OrderTranslator();
                    orderdetailsBE.Order = orderTranslator.Translate(orderdetails.Order);
                }
                if (orderdetails.Product != null)
                {
                    ProductTranslator productTranslator = new ProductTranslator();
                    orderdetailsBE.Product = productTranslator.Translate(orderdetails.Product);
                }
                return orderdetailsBE;
            }
            else 
            {
                return null;
            }

            
            
        }
        
        /// <summary>
        /// translate OrderDetailsBE type to OrderDetails type
        /// </summary>
        /// <param name="orderdetailsBE"></param>
        /// <returns></returns>
        public OrderDetails Translate(OrderDetailsBE orderdetailsBE)
        {
            if (orderdetailsBE != null)
            {
                OrderDetails orderdetails = new OrderDetails()
                {
                    OrderDetailId = orderdetailsBE.OrderDetailId,
                    OrderId = orderdetailsBE.OrderId,
                    ProductId = orderdetailsBE.ProductId,
                    Quantity = orderdetailsBE.Quantity,
                    TotalPrice = orderdetailsBE.TotalPrice,
                    IsDeleted = orderdetailsBE.IsDeleted
                };

                return orderdetails;
            }
            else
            {
                return null;
            }
            
        }
    }
}
