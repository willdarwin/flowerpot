using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DataEntity;
using System.Data.Entity;
using TTA.Model;

namespace TTA.DataManager
{
    public partial class CustomerManager
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>all the customers in a list</returns>
        public List<CustomerBE> GetAllCustomers()
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            List < Customer > listCustomerDE = (from Customer customer in DBEntity.Customers select customer).ToList<Customer>();
            List<CustomerBE> listCustomerBE = new List<CustomerBE>();
            foreach (Customer customerDE in listCustomerDE)
            {
                CustomerBE customerBE = new CustomerTranslator().Translate(customerDE);
                listCustomerBE.Add(customerBE);
            }
            return listCustomerBE;
        }

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="dbEntity"> Database Entity Container</param>
        /// <param name="customerBE">Customer DataEntity</param>
        public bool Insert(TTAEntityContainer dbEntity, CustomerBE customerBE)
        {
            dbEntity.AddToCustomers((new CustomerTranslator()).Translate(customerBE));
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
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer DataEntity</param>
        public bool Insert(CustomerBE customerBE)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Insert(DBEntity, customerBE);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="id">The id of a customer</param>
        public bool Delete(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Delete(DBEntity, id);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="dbEntity">Database Entity Container</param>
        /// <param name="id">The id of a customer</param>
        public bool Delete(TTAEntityContainer dbEntity, int id)
        {
            Customer customer = (from Customer c in dbEntity.Customers where c.CustomerId == id select c).SingleOrDefault<Customer>();// FirstOrDefault
            if (customer.Order.Count > 0)
            {
                throw new Exception("This Customer is referred by Order and you can not delete it");
            }
            dbEntity.Customers.DeleteObject(customer);
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
        /// Update a customer
        /// </summary>
        /// <param name="cus">Customer Business Entity</param>
        public bool Update(CustomerBE cus)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            return this.Update(DBEntity, cus);
        }

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="dbEntity">Database Entity Container</param>
        /// <param name="cus">Custome Bussiness Entity</param>
        public bool Update(TTAEntityContainer dbEntity, CustomerBE cus)
        {
            Customer customer = (from Customer c in dbEntity.Customers where c.CustomerId == cus.CustomerId select c).SingleOrDefault<Customer>();
            customer.CustomerName = cus.CustomerName;
            customer.CustomerGender = cus.CustomerGender;
            customer.AddressId = cus.Address.AddressId;
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
        /// Get a customer by Id
        /// </summary>
        /// <param name="id">The id of a customer</param>
        /// <returns>A customer</returns>
        public CustomerBE GetById(int id)
        {
            TTAEntityContainer DBEntity = new TTAEntityContainer();
            Customer customer = (from Customer c in DBEntity.Customers where c.CustomerId == id select c).SingleOrDefault<Customer>();
            return new CustomerTranslator().Translate(customer);
        }
    }
}
