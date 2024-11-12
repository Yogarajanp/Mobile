using MobileRepository.Model;

namespace MobileRepository.Base.DTO
{
    public class UserDropdownDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

    }
    public class UserClaimsModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public Role[] Role { get; set; }
    }
    public class LoginDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
