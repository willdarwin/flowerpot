using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataManager;
using TTA.DataEntity;
using System.Data.Entity;


namespace TTA.BLL
{
    public class CustomerService 
    {
        /// <summary>
        /// Get all the customers 
        /// </summary>
        /// <returns>All the customers in a list</returns>
        public List<CustomerBE> GetAllCustomers()
        {
            return new CustomerManager().GetAllCustomers();
        }

        
        /// <summary>
        /// Add a new Customer
        /// </summary>
        /// <param name="customerBE">customer Buiness Entity</param>
        public bool InsertCustomer(CustomerBE customerBE)
        {
            return new CustomerManager().Insert(customerBE);
        }

        /// <summary>
        /// Delete A customer by the Id
        /// </summary>
        /// <param name="id">The id of a customer</param>
        public bool DeleteCustomer(int id)
        {
                bool result = new CustomerManager().Delete(id);
                return result;
        }

        /// <summary>
        /// Update the Customer
        /// </summary>
        public bool UpdateCustomer(CustomerBE customerBE)
        {
            return new CustomerManager().Update(customerBE);
        }

        /// <summary>
        /// Get All Addresses
        /// </summary>
        public List<AddressBE> GetAllAddresses()
        {
            return new AddressManager().GetAllAddresses();
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        public CustomerBE GetCustomerById(int id)
        {
            return new CustomerManager().GetById(id);
        }

    }
}
