using System;
using System.Collections.Generic;
using System.Text;

namespace TTAPresentation.TTAProduct.Views
{
    public interface IUpdateProductView
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal ProductPrice { get; set; }
        int CategoryId { get; set; }
    }
}




