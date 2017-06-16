using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.DataEntity;

namespace TTA.DataManager
{
    public class CustomerTranslator
    {
        /// <summary>
        /// Translate customerDE to customerBE
        /// </summary>
        /// <param name="customerDE"></param>
        /// <returns></returns>
        public CustomerBE Translate(Customer customerDE)
        {
            if (customerDE != null)
            {
                CustomerBE customerBE = new CustomerBE()
                {
                    CustomerId = customerDE.CustomerId,
                    CustomerName = customerDE.CustomerName,
                    CustomerGender = customerDE.CustomerGender,
                    Address = new AddressBE()
                    {
                        AddressId = customerDE.Address.AddressId,
                        Country = customerDE.Address.Country,
                        Province = customerDE.Address.Province,
                        City = customerDE.Address.City,
                        DetailAddress = customerDE.Address.Address1,
                    },
                };
                return customerBE;
            } 
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Translate customerBE to customerDE
        /// </summary>
        /// <param name="customerBE"></param>
        /// <returns></returns>
        public Customer Translate(CustomerBE customerBE)
        {
            Customer customerDE = new Customer();
            customerDE.CustomerId = customerBE.CustomerId;
            customerDE.CustomerName = customerBE.CustomerName;
            customerDE.CustomerGender = customerBE.CustomerGender;
            customerDE.AddressId = customerBE.Address.AddressId;
            return customerDE;
        }
    }
}
