using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class OrderSearchResultBE //Lily
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }
    }
}
