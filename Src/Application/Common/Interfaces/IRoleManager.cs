using Application.Common.Models;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRoleManager
    {
        Task<Result> AddRoleAsync(string roleName);
    }
}
