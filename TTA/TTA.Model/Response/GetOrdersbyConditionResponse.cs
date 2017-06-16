using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class GetOrdersbyConditionResponse : ResponseBase
    {
        /// <summary>
        /// Order Business entity list.
        /// </summary>
        /// <value>
        /// The order list.
        /// </value>
        [DataMember]
        public List<OrderBE> OrderList { get; set; }
    }
}
