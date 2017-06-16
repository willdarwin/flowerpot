using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class SearchByConditionsResponse : ResponseBase
    {
        /// <summary>
        /// OrderSearchResult Business entity list.
        /// </summary>
        /// <value>
        /// The order search results list.
        /// </value>
        [DataMember]
        public List<OrderSearchResultBE> OrderSearchResultBEList { get; set; }

        [DataMember]
        public int RowCount { get; set; }
    }
}
