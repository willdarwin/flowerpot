using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTACustomer.Services
{
    public interface ICustomerService
    {
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
        List<TTA.Model.AddressBE> GetAllAddresses();
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        List<TTA.Model.CustomerBE> GetAllCustomers();
        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        CustomerBE GetCustomerById(int id);
        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        bool InsertCustomer(TTA.Model.CustomerBE customerBE);
        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="customerBE">The customer BE.</param>
        /// <returns></returns>
        bool UpdateCustomer(TTA.Model.CustomerBE customerBE);
    }
}
