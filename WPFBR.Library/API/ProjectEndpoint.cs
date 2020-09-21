using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public class ProjectEndpoint : IProjectEndpoint
    {
        private IAPIHelper _apiHelper;

        public ProjectEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProjectModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Project"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProjectModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task PostProject(ProjectModel project)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Project", project))
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

        public async Task UpdateProject(ProjectModel project)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("api/Project", project))
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

        public async Task DeleteProject(int projectId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/Project?projectId={ projectId }"))
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
