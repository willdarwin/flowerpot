using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class UpdateProductRequest : RequestBase
    {
        /// <summary>
        /// Product business entity.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        [DataMember]
        public ProductBE product { get; set; }
    }
}
