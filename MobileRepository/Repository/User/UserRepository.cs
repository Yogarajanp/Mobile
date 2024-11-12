using Microsoft.EntityFrameworkCore;
using MobileRepository.Base.UnitOfWork.Interface;
using MobileRepository.Model;

namespace MobileRepository.Repository.User

{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Model.User>> GetUserByRole(string role)
        {
            var roleId = await _unitOfWork.GetEntities<Role>()
                .SingleOrDefaultAsync(x => x.RoleName == role);
            return await _unitOfWork.GetEntities<UserRole>().Include(x => x.User).Where(x => x.Role.Id == roleId.Id).AsNoTracking().Select(x => x.User).ToListAsync();
        }
        public async Task<Model.User> GetUserById(long userId)
        {
            return await _unitOfWork.GetEntities<Model.User>().Where(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Model.User> GetUserByEmail(string email)
        {
            return await _unitOfWork.GetEntities<Model.User>().Where(x => x.EmailAddress == email).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<List<Role>> GetUserRoleByUserId(long userId)
        {
            return await _unitOfWork.GetEntities<UserRole>().Include(x => x.Role).Where(x => x.User.Id == userId).AsNoTracking()
                .Select(x => x.Role).Distinct().ToListAsync();
        }
        public async Task<bool> CreateUser(Model.User user)
        {

            await _unitOfWork.AddAsync(user);
            await _unitOfWork.CommitAsync();
            var userRole = new UserRole
            {
                Role = await _unitOfWork.GetEntities<Role>()
                    .FirstOrDefaultAsync(x => x.RoleName == "User"),
                User = user
            };
            return await CreateUserRole(userRole);
        }
        private async Task<bool> CreateUserRole(UserRole userHasRoles)
        {
            await _unitOfWork.AddAsync(userHasRoles);
            return await _unitOfWork.CommitAsync();
        }


    }
}