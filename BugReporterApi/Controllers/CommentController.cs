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
    public class CommentController : ApiController
    {
        public List<CommentModel> Get(int bugId)
        {
            CommentData data = new CommentData();
            var output = data.LoadComments(bugId);
            return output;
        }

        public void Post(CommentModel comment)
        {
            CommentData data = new CommentData();
            data.SaveComment(comment);
        }
    }
}
