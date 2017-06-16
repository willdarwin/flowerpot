using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class OrderBE // Sunny
    {
        [DataMember]
        public int OrderId { get; set; }
        
        [DataMember]
        public DateTime CreateTime { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int OrderStatusId { get; set; }

        [DataMember]
        public bool OrderCheckBoxFlag { get; set; }

        [DataMember]
        public CustomerBE Customer { get; set; }

        [DataMember]
        public OrderStatusBE OrderStatus { get; set; }

    }
}
