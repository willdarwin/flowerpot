using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class SearchByConditionsRequest : RequestBase
    {
        /// <summary>
        /// Order search condition.
        /// </summary>
        /// <value>
        /// The order search condition.
        /// </value>
        [DataMember]
        public OrderSearchParameterBE OrderSearchConditions { get; set; }
    }
}
