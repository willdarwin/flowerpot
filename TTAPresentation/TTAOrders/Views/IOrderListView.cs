using System;
using System.Collections.Generic;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public interface IOrderListView
    {
        int CurrentPageIndex { get; set; }
        int TotalPageCount { get; set; }
        string Name { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        int Id { get; set; }
    }
}




