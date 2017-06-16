using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class SelectAllCategoryResponse : ResponseBase
    {
        /// <summary>
        /// Category business entity list.
        /// </summary>
        /// <value>
        /// The category list.
        /// </value>
        [DataMember]
        public List<CategoryBE> CategoryList { get; set; }
    }
}
