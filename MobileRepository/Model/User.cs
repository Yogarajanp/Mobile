namespace MobileRepository.Model
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public required string Password { get; set; }
        public string HashedPassword { get; set; }
        public required string EmailAddress { get; set; }
        public required string Address { get; set; }
        public required string MobileNumber { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
