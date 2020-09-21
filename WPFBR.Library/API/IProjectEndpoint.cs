using System.Collections.Generic;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface IProjectEndpoint
    {
        Task DeleteProject(int projectId);
        Task<List<ProjectModel>> GetAll();
        Task PostProject(ProjectModel project);
        Task UpdateProject(ProjectModel project);
    }
}