using System;
using System.Collections.Generic;
using TTA.Model;

namespace TTAPresentation.TTACustomer
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITTACustomerController
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        List<CustomerBE> GetAllCustomers();

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        bool DeleteCustomer(int id);

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns></returns>
        List<AddressBE> GetAllAddresses();

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        CustomerBE GetCustomerById(int id);

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void InsertCustomer(CustomerBE customer);

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void UpdateCustomer(CustomerBE customer);
    }
}
