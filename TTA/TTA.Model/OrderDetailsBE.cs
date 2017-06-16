using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TTA.Model
{
    [DataContract]
    public class OrderDetailsBE //Eric
    {
        /// <summary>
        /// initialize public field
        /// </summary>
        /// 
        [DataMember]
        public int OrderDetailId { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Quantity { get; set; }     

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public OrderBE Order { get; set; }

        [DataMember]
        public ProductBE Product{ get;set; }

    }
}