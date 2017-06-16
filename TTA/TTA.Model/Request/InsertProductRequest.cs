using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class InsertProductRequest : RequestBase
    {
        /// <summary>
        /// Product business entity.
        /// </summary>
        /// <value>
        /// The product business entity.
        /// </value>
        [DataMember]
        public ProductBE Product { get; set; }
    }
}
