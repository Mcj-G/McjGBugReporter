using System.Collections.Generic;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface ICommentEndpoint
    {
        Task<List<CommentModel>> GetById(int bugId);
        Task PostComment(CommentModel comment);
    }
}