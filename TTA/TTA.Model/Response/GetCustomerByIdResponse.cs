using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class GetCustomerByIdResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets my customer.
        /// </summary>
        /// <value>
        /// My customer.
        /// </value>
        [DataMember]
        public CustomerBE MyCustomer { get; set; }
    }
}
