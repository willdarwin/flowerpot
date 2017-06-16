using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class OpenOrderRequest : RequestBase
    {
        [DataMember]
        public int OrderId { set; get; }

        [DataMember]
        public OrderBE Order { set; get; }
    }
}
