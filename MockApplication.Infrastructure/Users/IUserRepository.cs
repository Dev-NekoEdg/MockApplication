using MockApplication.Domain.Entities;

namespace MockApplication.Infrastructure.Users;
public interface IUserRepository
{
    Task<User> CreateAsync(User dto);
    Task<bool> DeleteAsync(string id);
    Task<User> ReadAsync(string id);
    Task<IList<User>> ReadAllAsync();
    Task<User> UpdateAsync(User dto);
}
