using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public class StatusEndpoint : IStatusEndpoint
    {
        private IAPIHelper _apiHelper;

        public StatusEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<StatusModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Status"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<StatusModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task UpdateStatus(int bugId, int newStatusId)
        {
            List<int> ids = new List<int>();
            ids.Add(bugId);
            ids.Add(newStatusId);

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Status", ids))
            {
                if (response.IsSuccessStatusCode)
                {
                    // TODO - log it
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
