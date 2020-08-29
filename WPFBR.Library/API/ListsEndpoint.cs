using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public class ListsEndpoint : IListsEndpoint
    {
        private IAPIHelper _apiHelper;

        public ListsEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<ListsModel> GetLists()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Lists"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ListsModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
