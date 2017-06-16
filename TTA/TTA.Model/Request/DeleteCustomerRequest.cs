using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class DeleteCustomerRequest : RequestBase
    {
        /// <summary>
        /// Id of Customer
        /// </summary>
        [DataMember]
        public int Id { get; set; }
    }
}
