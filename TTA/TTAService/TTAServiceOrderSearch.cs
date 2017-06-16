using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using TTA.BLL;
using TTA.IService;

namespace TTA.Service
{
    public partial class TTAService : ITTAService  //Lily
    {
        /// <summary>
        /// Search order results by conditions.  --By Lily
        /// </summary>
        /// <param name="searchByConditionsRequest"></param>
        /// <returns>Return a SearchByConditionsResponse object includes an OrderSearchResultBE object and a rowCount output.</returns>
        public SearchByConditionsResponse SearchByConditions(SearchByConditionsRequest searchByConditionsRequest)
        {
            int rowCount;
            OrderSearchService orderSearchService = new OrderSearchService();
            SearchByConditionsResponse searchByConditionsResponse = new SearchByConditionsResponse();

            try
            {
                searchByConditionsResponse.OrderSearchResultBEList = orderSearchService.SearchByConditions(searchByConditionsRequest.OrderSearchConditions, out rowCount);
                searchByConditionsResponse.RowCount = rowCount;
            }
            catch (Exception ex)
            {
                searchByConditionsResponse.IsFailed = true;
                searchByConditionsResponse.Message = ex.Message;
            }

            return searchByConditionsResponse;
        }
    }
}
