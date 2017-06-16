using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class GetOrdersbyConditionRequst : RequestBase
    {
        /// <summary>
        /// Order_search condition.
        /// </summary>
        /// <value>
        /// The order search condition.
        /// </value>
        [DataMember]
        public OrderSearchParameterBE OrderSearchCondition { get; set; }
    }
}
