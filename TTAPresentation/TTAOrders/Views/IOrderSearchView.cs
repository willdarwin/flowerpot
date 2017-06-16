using System;
using System.Collections.Generic;
using System.Text;
using TTA.Model;

namespace TTAPresentation.TTAOrders.Views
{
    public interface IOrderSearchView
    {
        string CustomerName { get; }
        string StartDate { get; }
        string EndDate { get; }
        string ProductName { get; }

        string SortExpression { get; set; }
        string SortDirection { get; set; }

        int PageSize { get; }
        int TotalPageCount { get; set; }
        int CurrentPageIndex { get; set; }

        string SelectedPage { get; }        
        List<string> PageList { get; set; }
    }
}




