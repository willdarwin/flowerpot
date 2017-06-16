using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TTA.Model
{
    /// <summary>
    /// Response Base of all service
    /// </summary>
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public bool IsFailed { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}
