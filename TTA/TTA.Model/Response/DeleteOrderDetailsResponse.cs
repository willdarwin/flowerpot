using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class DeleteOrderDetailsResponse:ResponseBase
    {
        [DataMember]
        public int OrderDetailsId { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public OrderDetailsBE OrderDetails { get; set; }
    }
}
