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
    public class ListsController : ApiController
    {
        public ListsModel Get()
        {
            ListsData data = new ListsData();

            return data.GetLists();
        }
    }
}
