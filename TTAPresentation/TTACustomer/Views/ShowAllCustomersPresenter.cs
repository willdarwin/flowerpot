using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTACustomer.Views
{
    public class ShowAllCustomersPresenter : Presenter<IShowAllCustomersView>
    {
        private ITTACustomerController _controller;
        public ShowAllCustomersPresenter([CreateNew] ITTACustomerController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Called when [view loaded].
        /// </summary>
        public override void OnViewLoaded()
        {
        }

        /// <summary>
        /// Called when [view initialized].
        /// </summary>
        public override void OnViewInitialized()
        {
        }


        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public List<CustomerBE> GetAllCustomers()
        {
            return _controller.GetAllCustomers();
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteCustomer(int id)
        {
            _controller.DeleteCustomer(id);
        }        
    }
}




