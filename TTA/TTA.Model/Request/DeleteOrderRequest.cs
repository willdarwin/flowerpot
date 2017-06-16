using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class DeleteOrderRequest : RequestBase
    {
        /// <summary>
        /// Order Id
        /// </summary>
        /// <value>
        /// The order id.
        /// </value>
        [DataMember]
        public int OrderId { get; set; }
    }
}
