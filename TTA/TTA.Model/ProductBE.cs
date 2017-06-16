using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class ProductBE //Will
    {

        [DataMember]
        public int ProductId { set; get; }
        [DataMember]
        public string ProductName { set; get; }
        [DataMember]
        public decimal ProductPrice { set; get; }
        [DataMember]
        public int CategoryId { set; get; }
        [DataMember]
        public CategoryBE Category { set; get; }

    }
}
