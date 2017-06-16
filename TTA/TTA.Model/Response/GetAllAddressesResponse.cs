using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class GetAllAddressesResponse : ResponseBase
    {
        /// <summary>
        /// The List of Addresses
        /// </summary>
        [DataMember]
        public List<AddressBE> AddressesList { get; set; }
    }
}
