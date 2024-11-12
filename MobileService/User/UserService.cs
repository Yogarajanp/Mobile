using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobileRepository.Base.DTO;
using MobileRepository.Repository.User;
using MobileService.ConfigSettings;
using MobileService.User.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobileServices.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
            _mapper = mapper;
        }
        public async Task<string> AuthenticateAsync(LoginDto loginUser)
        {
            var user = await _userRepository.GetUserByEmail(loginUser.EmailAddress);
            if (user == null || !verifyPassword(loginUser.Password, user.HashedPassword))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "User") // Replace with actual roles
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Result<MessageDto>> CreateUser(UserDto userDto)
        {

            var existingUser = await _userRepository.GetUserByEmail(userDto.EmailAddress);
            if (existingUser != null)
            {
                return new Result<MessageDto>().AddError("User already exists.");
            }

            var createProject = _mapper.Map<MobileRepository.Model.User>(userDto);
            createProject.HashedPassword = HashPassword(userDto.Password);
            createProject.CreatedBy = "admin";
            createProject.CreatedDate = DateTime.Now;
            createProject.IsDeleted = false;

            var result = await _userRepository.CreateUser(createProject);


            return result
                ? new Result<MessageDto> { Data = new MessageDto().AddMessage("User Created Successfully") }
                : new Result<MessageDto>().AddError("Unable to Create User.");
        }

        /*public Task<MobileRepository.Model.User> CreateUserGetUser(string emailId)
        {
            throw new NotImplementedException();
        }

        public Task<MobileRepository.Model.User> GetorCreateUserByEmail(string reviewerEmailId)
        {
            throw new NotImplementedException();
        }

        public Task<MobileRepository.Model.User> GetUserByEmailId(string emailId)
        {
            throw new NotImplementedException();
        }*/

        /*public Task<List<Role>> GetUserRoleByUserId(long userId)
        {
            throw new NotImplementedException();
        }*/


        public string HashPassword(string password)
        {

            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public Boolean verifyPassword(string hashedpassword, string password)
        {

            return BCrypt.Net.BCrypt.Verify(hashedpassword, password);
        }
    }
}
