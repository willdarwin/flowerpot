using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

namespace TTA.DataManager
{
    public class OrderDetailsManager
    {
        /// <summary>
        /// select list of all orderdetails for gridview datasource
        /// </summary>
        /// <returns></returns>
        public List<OrderDetailsBE> GetAllOrderDetails()
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            List<OrderDetails> list = (from OrderDetails orderdetails in dbEntity.OrderDetails
                                       where orderdetails.IsDeleted == false
                                       select orderdetails).ToList<OrderDetails>();
            List<OrderDetailsBE> listBE = new List<OrderDetailsBE>();
            foreach (OrderDetails orderdetails in list)
            {
                OrderDetailsBE orderdetailsBE = new OrderDetailsTranslator().Translate(orderdetails);
                listBE.Add(orderdetailsBE);
            }
            return listBE;
        }

        /// <summary>
        /// select list of orderdetails by orderid for gridview datasource
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderDetailsBE> GetOrderDetailsByOrderId(int orderId)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            List<OrderDetails> list = (from OrderDetails orderdetails in dbEntity.OrderDetails
                                       where orderdetails.OrderId == orderId && orderdetails.IsDeleted == false
                                       select orderdetails).ToList<OrderDetails>();
            List<OrderDetailsBE> listBE = new List<OrderDetailsBE>();
            foreach (OrderDetails orderdetails in list)
            {
                OrderDetailsBE orderdetailsBE = new OrderDetailsTranslator().Translate(orderdetails);
                listBE.Add(orderdetailsBE);
            }
            return listBE;
        }

        /// <summary>
        /// insert a piece of orderdetails record by new inserted orderid linked by its corresponding createdtime 
        /// </summary>
        /// <param name="orderdetails"></param>
        public bool Insert(OrderDetailsBE orderdetailsBE)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            OrderDetails orderdetails = new OrderDetailsTranslator().Translate(orderdetailsBE);
            dbEntity.AddToOrderDetails(orderdetails);
            int result=dbEntity.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// update a piece of orderdetail by its corresponding orderdetailid
        /// </summary>
        /// <param name="od"></param>
        public bool Update(OrderDetailsBE odBE)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            OrderDetails orderdetails = (from OrderDetails o in dbEntity.OrderDetails
                                         where o.OrderDetailId == odBE.OrderDetailId
                                         select o).SingleOrDefault<OrderDetails>();
            orderdetails.ProductId = odBE.ProductId;
            orderdetails.Quantity = odBE.Quantity;
            orderdetails.TotalPrice = odBE.TotalPrice;
            int result = dbEntity.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// update a piece of orderdetail by its corresponding orderdetailid
        /// </summary>
        /// <param name="id"></param>
        public bool Close(OrderDetailsBE odBE)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            OrderDetails orderdetails = (from OrderDetails o in dbEntity.OrderDetails
                                         where o.OrderDetailId == odBE.OrderDetailId
                                         select o).SingleOrDefault<OrderDetails>();
            orderdetails.IsDeleted = true;
            //dbEntity.OrderDetails.DeleteObject(orderdetails);
            int result=dbEntity.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// delete a piece of orderdetail by its corresponding orderdetailid
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            TTAEntityContainer dbEntity = new TTAEntityContainer();
            OrderDetails orderdetails = (from OrderDetails o in dbEntity.OrderDetails
                                         where o.OrderDetailId == id
                                         select o).SingleOrDefault<OrderDetails>();
            dbEntity.OrderDetails.DeleteObject(orderdetails);
            int result = dbEntity.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
