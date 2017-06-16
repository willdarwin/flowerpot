using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.DAL.DataAccess;
using TTA.Model;

namespace TTA.BLL
{
    public class R1_Service
    {
        AddressDA _mAddressDA = new AddressDA();
        CustomerDA _mCustomerDA = new CustomerDA();

        public List<CustomerDE> GetAllCustomers()
        {
            return _mCustomerDA.GetAllCustomers();
        }

        public CustomerDE InsertCustomer(CustomerDE customer)
        {
            return _mCustomerDA.Insert(customer);

        }

        public bool DeleteCustomer(int id)
        {
            return _mCustomerDA.Delete(id);
        }

        public bool UpdateCustomer(CustomerDE customer)
        {
            return _mCustomerDA.Update(customer);
        }

        public List<AddressDE> GetAllAddresses()
        {
            return _mAddressDA.GetAllAddresses();
        }

        public CustomerDE GetCustomerById(int id)
        {
            return _mCustomerDA.GetById(id);
        }
    }
}
