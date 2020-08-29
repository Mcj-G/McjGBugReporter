using System.Net.Http;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace WPFBR.Library.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}