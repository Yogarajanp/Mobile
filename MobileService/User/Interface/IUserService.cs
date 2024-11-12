using MobileRepository.Base.DTO;

namespace MobileService.User.Interface
{
    public interface IUserService
    {
        //Task<Result<List<UserDropdownDto>>> GetUserByRole(string role);
        Task<Result<MessageDto>> CreateUser(UserDto userDto);



        //Task<MobileRepository.Model.User> GetUserByEmailId(string emailId);
        //Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);



        //Task<List<Role>> GetUserRoleByUserId(long userId);
        //Task<List<UserClaimsModel>> GetUserClaims(string emailId);
        //UserModel GetCurrentUser(ClaimsPrincipal user);
        //Task<MobileRepository.Model.User> GetorCreateUserByEmail(string reviewerEmailId);
        Task<string> AuthenticateAsync(LoginDto loginUser);
        string HashPassword(string password);
        public Boolean verifyPassword(string hashedpassword, string password);
    }

}
