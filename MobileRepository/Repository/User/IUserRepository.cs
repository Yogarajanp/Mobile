using MobileRepository.Model;

namespace MobileRepository.Repository.User
{
    public interface IUserRepository
    {
        Task<Model.User> GetUserById(long userId);
        Task<Model.User> GetUserByEmail(string email);
        Task<List<Model.User>> GetUserByRole(string role);
        Task<bool> CreateUser(Model.User user);
        Task<List<Role>> GetUserRoleByUserId(long userId);

    }
}
