using System;
using System.Collections.Generic;
using System.Text;

namespace TTAPresentation.TTAOrders.Views
{
    public interface IUpdateOrderDetailsView
    {
        int OrderId { get; set; }
        int OrderDetailsId { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
        decimal TotalPrice { get; set; }
    }
}




