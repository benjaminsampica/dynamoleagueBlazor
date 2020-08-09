using Application.Common.Models;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        Task<Result> AddToRoleAsync(string userId, string role);
    }
}
