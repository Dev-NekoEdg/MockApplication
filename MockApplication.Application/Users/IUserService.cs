using MockApplication.Domain.Models;

namespace MockApplication.Application.Users;

public interface IUserService
{
    Task<UserModel> CreateUserAsync(UserModel model);
}