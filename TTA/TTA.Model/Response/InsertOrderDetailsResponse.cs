using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class InsertOrderDetailsResponse:ResponseBase
    {
        [DataMember]
        public OrderDetailsBE OrderDetailsBE { get; set; }
    }
}
