using MockApplication.Domain.Entities;
using MockApplication.Domain.Models;

namespace MockApplication.Domain.Converts;

public static class UserConverts
{

    public static UserModel ToModel(this Entities.User entity)
    {
        return new UserModel
        {
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            IdentificationType = entity.IdentificationType,
            IdentificationNumber = entity.IdentificationNumber,
            DateBirth = entity.DateBirth,
            Height = entity.Height,
            Weight = entity.Weight,
            HasAnyDisabilitys = entity.HasAnyDisabilitys
        };
    }

    public static User ToDto(this UserModel entity)
    {
        return new User
        {
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            IdentificationType = entity.IdentificationType,
            IdentificationNumber = entity.IdentificationNumber,
            DateBirth = entity.DateBirth,
            Height = entity.Height,
            Weight = entity.Weight,
            HasAnyDisabilitys = entity.HasAnyDisabilitys
        };
    }
}
