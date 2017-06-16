using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.BLL;
using TTA.Model;
using TTA.IService;
using System.Reflection;
using System.Transactions;

namespace TTA.Service
{
    public partial class TTAService : ITTAService
    {

        #region ITTAService Members

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest request)
        {
             CustomerService service = new CustomerService();
             DeleteCustomerResponse response = new DeleteCustomerResponse();
            try
            {
                service.DeleteCustomer(request.Id);
            }
            catch (System.Exception ex)
            {
                response.IsFailed = true;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns></returns>
        public GetAllAddressesResponse GetAllAddresses(GetAllAddressesRequest request)
        {
            CustomerService service = new CustomerService();
            GetAllAddressesResponse response = new GetAllAddressesResponse();
            try
            {
                response.AddressesList = service.GetAllAddresses();
            }
            catch (System.Exception ex)
            {
                response.Message = ex.ToString();
                response.IsFailed = true;
            }
            return response;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public GetAllCustomersResponse GetAllCustomers(GetAllCustomersRequest request)
        {
            CustomerService service = new CustomerService();
            GetAllCustomersResponse response = new GetAllCustomersResponse();
            try
            {
                response.CustomersList = service.GetAllCustomers();
            }
            catch (System.Exception ex)
            {
                response.Message = ex.ToString();
                response.IsFailed = true;
            }
            return response;
        }

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public GetCustomerByIdResponse GetCustomerById(GetCustomerByIdRequest request)
        {
            CustomerService service = new CustomerService();
            GetCustomerByIdResponse response = new GetCustomerByIdResponse();
            try
            {
                response.MyCustomer = service.GetCustomerById(request.Id);
            }
            catch (System.Exception ex)
            {
                response.Message = ex.ToString();
                response.IsFailed = true;
            }
            return response;
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public InsertCustomerResponse InsertCustomer(InsertCustomerRequest request)
        {
            CustomerService service = new CustomerService();
            InsertCustomerResponse response = new InsertCustomerResponse();
            response.IsFailed = !(service.InsertCustomer(request.MyCustomer));
            return response;
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            CustomerService service = new CustomerService();
            UpdateCustomerResponse response = new UpdateCustomerResponse();
            response.IsFailed = !(service.UpdateCustomer(request.MyCustomer));
            return response;
        }

        #endregion
    }
}


