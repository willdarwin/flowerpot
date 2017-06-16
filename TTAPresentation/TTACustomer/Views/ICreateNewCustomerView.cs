using System;
using System.Collections.Generic;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTACustomer.Views
{
    public interface ICreateNewCustomerView
    {
        string CustomerName { get; set; }
        bool CustomerGender { get; set; }
        int CustomerAddressId { get; set; }
        int CustomerId { get; set; }
    }
}




