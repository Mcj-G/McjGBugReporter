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
    public class StatusController : ApiController
    {
        public List<StatusModel> Get()
        {
            StatusData data = new StatusData();

            return data.GetStatusList();
        }

        public void Post(List<int> ids)
        {
            int bugId = ids[0];
            int newStatusId =ids[1];

            StatusData data = new StatusData();

            data.UpdateStatus(bugId, newStatusId);
        }
    }
}
