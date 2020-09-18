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
    public class BugController : ApiController
    {
        public List<BugDisplayModel> Get()
        {
            BugData data = new BugData();
            var output = data.LoadBugs();
            return output;
        }
        public void Post(BugModel bug)
        {
            BugData data = new BugData();
            data.SaveBug(bug);
        }

        public void Put(List<string> idList)
        {
            BugData data = new BugData();
            data.UpdateAssignedUser(idList);
        }
    }
}
