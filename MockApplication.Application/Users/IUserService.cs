using MockApplication.Domain.Models;

namespace MockApplication.Application.Users;

public interface IUserService
{
    Task<UserModel> CreateUserAsync(UserModel model);
    Task<IList<UserModel>> GetUsersAsync();
    Task<UserModel> GetUserByIdAsync(string id);
    Task<UserModel> UpdateUserAsync(UserModel user);
    Task<bool> DeleteUserAsync(string id);
}