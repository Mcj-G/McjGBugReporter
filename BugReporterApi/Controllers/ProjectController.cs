using ApiBR.Library.DataAccess;
using ApiBR.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugReporterApi.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        public List<ProjectModel> Get()
        {
            ProjectData data = new ProjectData();
            var output = data.LoadProjects();
            return output;
        }

        public void Post(ProjectModel project)
        {
            ProjectData data = new ProjectData();
            data.SaveProject(project);
        }

        public void Put(ProjectModel project)
        {
            ProjectData data = new ProjectData();
            data.UpdateProject(project);
        }

        public void Delete(int projectId)
        {
            ProjectData data = new ProjectData();
            data.DeleteProject(projectId);
        }
    }
}
