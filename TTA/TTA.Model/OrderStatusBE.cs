using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class OrderStatusBE //Sunny
    {
        [DataMember]
        public int OrderStatusId { get; set; }

        [DataMember]
        public string StatusName { get; set; }
    }
}
