using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class SelectAllProductResponse : ResponseBase
    {
        /// <summary>
        /// Product business entity list.
        /// </summary>
        /// <value>
        /// The product list.
        /// </value>
        [DataMember]
        public List<ProductBE> ProductList { get; set; }
    }
}
