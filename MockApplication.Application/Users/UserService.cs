using MockApplication.Domain.Converts;
using MockApplication.Domain.Entities;
using MockApplication.Domain.Models;
using MockApplication.Infrastructure.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockApplication.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            // var parcedIdentification = this.ParseEmun(client.IdentificationType.ToString());
            var newUser = model.ToDto();
            newUser.UserId = Guid.NewGuid().ToString();

            var resultUser = await this.repository.CreateAsync(newUser);
            return resultUser.ToModel();
        }

        public async Task<IList<UserModel>> GetUsersAsync()
        {
            // var parcedIdentification = this.ParseEmun(client.IdentificationType.ToString());
            var result = await this.repository.ReadAllAsync();

            return result.Select(u => u.ToModel()).ToList();
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            // var parcedIdentification = this.ParseEmun(client.IdentificationType.ToString());
            var result = await this.repository.ReadAsync(id);

            return result.ToModel();
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            // var parcedIdentification = this.ParseEmun(client.IdentificationType.ToString());
            var result = await this.repository.UpdateAsync(user.ToDto());

            return result.ToModel();
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            // var parcedIdentification = this.ParseEmun(client.IdentificationType.ToString());
            var result = await this.repository.DeleteAsync(id);

            return result;
        }

        //private IdentificationType ParseEmun(string value)
        //{
        //    var objParced = Enum.Parse(typeof(IdentificationType), value.ToUpper());
        //    return (IdentificationType)objParced;
        //}
    }
}
