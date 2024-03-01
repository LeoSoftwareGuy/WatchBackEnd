using Application.Support.Models;
using System.Threading.Tasks;

namespace Application.Support.Interfaces
{
    public interface IUserManager
    {
        // Returns result of an operation along with ID of created user
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        // Only returns result of an operation
        Task<Result> DeleteUserAsync(string userId);
    }
}
