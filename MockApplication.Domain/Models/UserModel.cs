using MockApplication.Domain.Entities;
using System.Text.Json.Serialization;

namespace MockApplication.Domain.Models;

public class UserModel
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public IdentificationType IdentificationType { get; set; }
    public string IdentificationNumber { get; set; }
    public DateTime DateBirth { get; set; } = DateTime.UtcNow;
    public double Height { get; set; }
    public double Weight { get; set; }
    public bool HasAnyDisabilitys { get; set; }
}
