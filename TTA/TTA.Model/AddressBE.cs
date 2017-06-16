using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace TTA.Model
{
    [DataContract]
    public class AddressBE //Robin
    {
        [DataMember]
        public int AddressId { set; get; }

        [DataMember]
        public string Country { set; get; }

        [DataMember]
        public string Province { set; get; }

        [DataMember]
        public string City { set; get; }

        [DataMember]
        public string DetailAddress { set; get; }


        public override string ToString()
        {
            return this.Country;
        }
    }
}
