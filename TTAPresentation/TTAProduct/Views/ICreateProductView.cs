using System;
using System.Collections.Generic;
using System.Text;

namespace TTAPresentation.TTAProduct.Views
{
    public interface ICreateProductView
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal ProductPrice { get; set; }
        int CategoryId { get; set; }
    }
}
