using MockApplication.Domain.Entities;

namespace MockApplication.Infrastructure.Users;
public interface IUserRepository
    {
        Task<User> Create(User dto);
        Task<bool> Delete(string id);
        Task<IList<User>> Read(string id);
        Task<User> Update(User dto);
    }
