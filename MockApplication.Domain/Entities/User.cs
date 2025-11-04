namespace MockApplication.Domain.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateBirth { get; set; } = DateTime.UtcNow;
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool HasAnyDisabilitys { get; set; }

        public User()
        {
            this.UserId = Guid.NewGuid().ToString();
        }
    }
}
