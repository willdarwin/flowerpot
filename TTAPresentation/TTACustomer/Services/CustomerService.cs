using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.ServiceProxy;

namespace TTAPresentation.TTACustomer.Services
{
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        {
            Proxy proxy = new Proxy();
            return proxy.DeleteCustomer(id);
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns></returns>
        public List<TTA.Model.AddressBE> GetAllAddresses()
        {
            Proxy proxy = new Proxy();
            return proxy.GetAllAddresses();
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public List<TTA.Model.CustomerBE> GetAllCustomers()
        {
            Proxy proxy = new Proxy();
            return proxy.GetAllCustomers();
        }

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public TTA.Model.CustomerBE GetCustomerById(int id)
        {
            Proxy proxy = new Proxy();
            return proxy.GetCustomerById(id);
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        public bool InsertCustomer(TTA.Model.CustomerBE customerBE)
        {
            Proxy proxy = new Proxy();
            return proxy.InsertCustomer(customerBE);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        public bool UpdateCustomer(TTA.Model.CustomerBE customerBE)
        {
            Proxy proxy = new Proxy();
            return proxy.UpdateCustomer(customerBE);
        }
    }
}
