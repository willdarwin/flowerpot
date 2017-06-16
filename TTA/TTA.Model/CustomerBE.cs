using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class CustomerBE //Robin
    {
        [DataMember]
        public int CustomerId { set; get; }

        [DataMember]
        public string CustomerName { set; get; }

        [DataMember]
        public bool CustomerGender { set; get; }

        [DataMember]
        public AddressBE Address { set; get; }

    }
}
