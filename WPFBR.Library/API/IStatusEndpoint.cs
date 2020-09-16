using System.Collections.Generic;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface IStatusEndpoint
    {
        Task<List<StatusModel>> GetAll();
        Task UpdateStatus(int bugId, int newStatusId);
    }
}