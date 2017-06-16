using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    /// <summary>
    /// The parameter business entity class of OrderSearchService .
    /// </summary>
    [DataContract]
    public class OrderSearchParameterBE //Lily
    {
        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string EndDate { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string SortExpression { get; set; }

        [DataMember]
        public string SortDirection { get; set; }

        [DataMember]
        public int PageStart { get; set; }

        [DataMember]
        public int PageEnd { get; set; }     
    }
}
