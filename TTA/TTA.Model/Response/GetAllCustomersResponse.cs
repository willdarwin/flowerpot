using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class GetAllCustomersResponse : ResponseBase
    {

        /// <summary>
        /// Gets or sets the customers list.
        /// </summary>
        /// <value>
        /// The customers list.
        /// </value>
        [DataMember]
        public List<CustomerBE> CustomersList { set; get; }

    }
}
