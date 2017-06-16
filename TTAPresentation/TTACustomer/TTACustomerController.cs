using System;
using TTAPresentation.TTACustomer.Services;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;
using System.Collections.Generic;

namespace TTAPresentation.TTACustomer
{
    public class TTACustomerController : ITTACustomerController
    {
        /// <summary>
        /// Sets the customer service.
        /// </summary>
        /// <value>
        /// The customer service.
        /// </value>
        private ICustomerService _customerService;        
        [ServiceDependency]
        public ICustomerService CustomerService
        {
            set { _customerService = value; }
        }

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual CustomerBE GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public virtual List<CustomerBE> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual bool DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public List<AddressBE> GetAllAddresses()
        {
            return _customerService.GetAllAddresses();
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void InsertCustomer(CustomerBE customer)
        {
            _customerService.InsertCustomer(customer);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void UpdateCustomer(CustomerBE customer)
        {
            _customerService.UpdateCustomer(customer);
        }
    }
}
