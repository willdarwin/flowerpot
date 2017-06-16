using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

namespace TTA.DataManager
{

    public partial class OrderManager
    {
        private int initialData = -1;
        /// <summary>
        /// Status of order.
        /// </summary>
        private enum Status : int
        {
            Open = 1,
            Closed = 2,
            Deleted = 3,
        }


        #region public method
        /// <summary>
        /// Insert order.
        /// </summary>
        /// <param name="orderBE">The order.</param>
        public OrderBE Insert(OrderBE orderBE)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Insert(DBEntity, orderBE);
        }

        /// <summary>
        /// Inserts order.
        /// </summary>
        /// <param name="DBEntity">The TTAEntityContainer.</param>
        /// <param name="order">The order.</param>
        public OrderBE Insert(TTAEntityContainer DBEntity, OrderBE orderBE)
        {
            OrderTranslator translator = new OrderTranslator();
            Order order = null;
            if (orderBE != null)
            {
                order = translator.Translate(orderBE);
                DBEntity.AddToOrders(order);
                DBEntity.SaveChanges();
            }
            return translator.Translate(order);
        }

        /// <summary>
        /// Deletes order.
        /// </summary>
        public bool Delete(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Delete(DBEntity, id);
        }

        /// <summary>
        /// Convert order status into delete status.
        /// </summary>
        /// <param name="dBEntity">The entity frame work data entity.</param>
        /// <param name="id">The id.</param>
        public bool Delete(TTAEntityContainer dBEntity, int id)
        {
            int result = initialData;
            if (id >= 0)
            {
                Order temp = this.GetDEById(dBEntity, id);
                Status status = Status.Deleted;
                temp.StatusId = (int)status;
                result = dBEntity.SaveChanges();
            }
            if (result != initialData)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes order from DataBase according to customer id.
        /// </summary>
        /// <param name="customerId">customer id.</param>
        /// <returns></returns>
        public bool DeleteFromDB(int customerId)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.DeleteFromDB(DBEntity, customerId);
        }

        /// <summary>
        /// Deletes order from database according to customerID.
        /// </summary>
        /// <param name="dBEntity">The data container.</param>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public bool DeleteFromDB(TTAEntityContainer dBEntity, int customerId)
        {
            int result = initialData;
            if (customerId > 0)
            {
                List<Order> list = (from Order order in dBEntity.Orders where order.CustomerId == customerId select order).ToList();
                foreach (Order order in list)
                {
                    Order temp = order;
                    dBEntity.Orders.DeleteObject(temp);
                }
                dBEntity.SaveChanges();
            }
            if (result != initialData)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates order.        -By  Eric
        /// </summary>
        /// <param name="order">The order.</param>
        public bool Update(OrderBE orderBE)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Update(DBEntity, orderBE);
        }

        /// <summary>
        /// Updates order.
        /// </summary>
        /// <param name="dBEntity">The entity frame work data entity.</param>
        /// <param name="orderBE">The order.</param>
        public bool Update(TTAEntityContainer dBEntity, OrderBE orderBE)
        {
            int result = initialData;
            if (orderBE != null)
            {
                Order temp = this.GetDEById(dBEntity, orderBE.OrderId);
                temp.StatusId = orderBE.OrderStatusId;
                temp.OrderStatus.StatusId = orderBE.OrderStatus.OrderStatusId;
                temp.OrderStatus.StatusName = orderBE.OrderStatus.StatusName;
                result = dBEntity.SaveChanges();
            }
            if (result != initialData)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Closes order.
        /// </summary>
        public bool Close(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Close(DBEntity, id);
        }

        /// <summary>
        /// Closes order.
        /// </summary>
        /// <param name="dBEntity">The entity frame work data entity.</param>
        /// <param name="id">The id.</param>
        public bool Close(TTAEntityContainer dBEntity, int id)
        {
            Status status = Status.Closed;
            Order temp = new Order();
            int result = initialData;
            if (id > 0)
            {
                temp = this.GetDEById(dBEntity, id);
                temp.StatusId = (int)status;
                result = dBEntity.SaveChanges();
            }
            if (result != initialData)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets order by id.
        /// </summary>
        /// <returns></returns>
        public OrderBE GetById(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.GetById(DBEntity, id);
        }

        /// <summary>
        /// Gets order by id.
        /// </summary>
        /// <param name="dBEntity">The entity frame work data entity.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public OrderBE GetById(TTAEntityContainer dBEntity, int id)
        {
            Order order = null;
            OrderTranslator translator = new OrderTranslator();
            if (id >= 0)
            {
                order = (from Order o in dBEntity.Orders where o.OrderId == id select o).SingleOrDefault<Order>();
            }
            return translator.Translate(order);
        }

        /// <summary>
        /// Gets order data entity by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Order GetDEById(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.GetDEById(DBEntity, id);
 
        }

        /// <summary>
        /// Gets order data entity by id.
        /// </summary>
        /// <param name="dBEntity">The d B entity.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Order GetDEById(TTAEntityContainer dBEntity, int id)
        {
            Order order = null;
            if (id > 0) 
            {
                order = (from Order o in dBEntity.Orders where o.OrderId == id select o).SingleOrDefault<Order>();
            }
            return order;
        }

        /// <summary>
        /// Gets order by condition.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="oper">The operator.</param>
        /// <returns></returns>
        public List<OrderBE> GetByCondition(TTAEntityContainer dBEntity, string name, string startDate, string endDate)
        {
            List<Order> list = new List<Order>();
            DateTime startDateTime = DateTime.MinValue;
            DateTime endDateTime = DateTime.MaxValue;

            if (!startDate.Equals(string.Empty))
            {
                startDateTime = Convert.ToDateTime(startDate);
            }
            if (!endDate.Equals(string.Empty))
            {
                endDateTime = Convert.ToDateTime(endDate);
            }
            Status status = Status.Deleted;

            list = (from Order o in dBEntity.Orders where o.StatusId != (int)status && o.Customer.CustomerName.Contains(name) && o.CreatedDate >= startDateTime && o.CreatedDate <= endDateTime select o).ToList();

            List<OrderBE> orderList = new List<OrderBE>();
            OrderTranslator translator = new OrderTranslator();
            foreach (Order order in list)
            {
                OrderBE orderBE = translator.Translate(order);
                orderList.Add(orderBE);
            }
            return orderList;
        }

        /// <summary>
        /// Gets orders by condition.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="startDate">The date.</param>
        /// <param name="endDate">The operator.</param>
        /// <returns></returns>
        public List<OrderBE> GetByCondition(string name, string startDate, string endDate)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            List<OrderBE> list = this.GetByCondition(DBEntity, name, startDate, endDate);
            return list;
        }

        /// <summary>
        /// Gets the by customer ID.
        /// </summary>
        /// <param name="dBEntity">The d B entity.</param>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public List<OrderBE> GetByCustomerID(TTAEntityContainer dBEntity,int customerId) 
        {
            List<Order> orderList = null;
            List<OrderBE> resultList = null;
            OrderTranslator translator = new OrderTranslator();
            if (customerId >= 0)
            {
                orderList = (from Order o in dBEntity.Orders where o.CustomerId == customerId select o).ToList<Order>();
            }
            foreach (Order order in orderList) 
            {
                OrderBE orderBE = translator.Translate(order);
                resultList.Add(orderBE);
            }
            return resultList;
        }

        /// <summary>
        /// Gets the by customer ID.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public List<OrderBE> GetByCustomerID(int customerId) 
        {
            TTAEntityContainer dBEntity = new TTAEntityContainer();
            List<OrderBE> list = this.GetByCustomerID(dBEntity, customerId);
            return list;
        }
        #endregion
    }
}
