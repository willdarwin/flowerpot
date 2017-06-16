using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class DeleteProductRequst : RequestBase
    {
        /// <summary>
        /// ProductId.
        /// </summary>
        /// <value>
        /// The product id.
        /// </value>
        [DataMember]
        public int ProductId { get; set; }
    }
}
