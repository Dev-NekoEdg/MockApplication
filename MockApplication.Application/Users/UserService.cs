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

            var resultUser = await this.repository.Create(newUser);
            return resultUser.ToModel();
        }


        //private IdentificationType ParseEmun(string value)
        //{
        //    var objParced = Enum.Parse(typeof(IdentificationType), value.ToUpper());
        //    return (IdentificationType)objParced;
        //}
    }
}
