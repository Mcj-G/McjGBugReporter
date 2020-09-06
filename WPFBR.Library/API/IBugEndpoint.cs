using System.Collections.Generic;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface IBugEndpoint
    {
        Task PostBug(BugModel bug);
        Task<List<BugDisplayModel>> GetAll();
    }
}