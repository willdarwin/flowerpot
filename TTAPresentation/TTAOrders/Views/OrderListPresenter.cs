using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public class OrderListPresenter : Presenter<IOrderListView>
    {
        /// <summary>
        /// Controller of Orders.
        /// </summary>
        private ITTAOrdersController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderListPresenter"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public OrderListPresenter([CreateNew] ITTAOrdersController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Closes the order.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool CloseOrder(int id) 
        {
            return _controller.CloseOrder(id);
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteOrder(int id) 
        {
            return _controller.DeleteOrder(id);
        }

        /// <summary>
        /// Gets the orders by condition.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<OrderBE> GetOrdersByCondition(string customerName, string startDate, string endDate) 
        {
            return _controller.GetOrdersbyCondition(customerName, startDate, endDate);
        }

        /// <summary>
        /// Gets the first page.
        /// </summary>
        public void GetFirstPage()
        {
            View.CurrentPageIndex = 0;
        }

        /// <summary>
        /// Gets the pre page.
        /// </summary>
        public void GetPrePage()
        {
            View.CurrentPageIndex--;
        }

        /// <summary>
        /// Gets the next page.
        /// </summary>
        public void GetNextPage()
        {
           View.CurrentPageIndex++;
        }

        /// <summary>
        /// Gets the last page.
        /// </summary>
        public void GetLastPage() 
        {
           View.CurrentPageIndex = View.TotalPageCount - 1;
        }
    }
}




