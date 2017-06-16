using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using TTA.Model;

namespace TTAPresentation.TTACustomer.Views
{
    public class CreateNewCustomerPresenter : Presenter<ICreateNewCustomerView>
    {
        private ITTACustomerController _controller;
        public CreateNewCustomerPresenter([CreateNew] ITTACustomerController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public CustomerBE GetCustomerById()
        {
            return _controller.GetCustomerById(View.CustomerId);
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="gender">if set to <c>true</c> [gender].</param>
        /// <param name="addressId">The address id.</param>
        public void InsertCustomer()
        {
            CustomerBE customer = new CustomerBE();
            customer.CustomerName = View.CustomerName;
            customer.CustomerGender = View.CustomerGender;
            AddressBE address = new AddressBE();
            address.AddressId = View.CustomerAddressId;
            address.City = "City";
            address.Country = "Country";
            address.DetailAddress = "Detail";
            address.Province = "Province";
            customer.Address = address;
            _controller.InsertCustomer(customer);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="gender">if set to <c>true</c> [gender].</param>
        /// <param name="addressId">The address id.</param>
        /// <param name="customerId">The customer id.</param>
        public void UpdateCustomer()
        {
            CustomerBE customer = new CustomerBE();
            customer.CustomerId = View.CustomerId;
            customer.CustomerName = View.CustomerName;
            customer.CustomerGender = View.CustomerGender;
            AddressBE address = new AddressBE();
            address.AddressId = View.CustomerAddressId;
            address.City = "City";
            address.Country = "Country";
            address.DetailAddress = "Detail";
            address.Province = "Province";
            customer.Address = address;
            _controller.UpdateCustomer(customer);
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns></returns>
        public List<AddressBE> GetAllAddresses()
        {
            return _controller.GetAllAddresses();
        }

    }
}




