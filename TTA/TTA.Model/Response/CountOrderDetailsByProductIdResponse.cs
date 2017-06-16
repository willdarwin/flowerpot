using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class CountOrderDetailsByProductIdResponse:ResponseBase
    {
        [DataMember]
        public int count { get; set; }
    }
}
