using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface IListsEndpoint
    {
        Task<ListsModel> GetLists();
    }
}