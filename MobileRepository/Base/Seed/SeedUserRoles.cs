using MobileRepository.Base.Context;
using MobileRepository.Model;

namespace MobileRepository.Base.Seed
{
    public class SeedUserRoles
    {
        public static void Initialize(MobileContext context)
        {
            // Check if data is already seeded
            if (!context.UserRoles.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Name == "admin");
                var role1 = context.Roles.FirstOrDefault(r => r.RoleName == "Admin");



                context.UserRoles.AddRange(
                    new UserRole { User = user1, Role = role1 }  // Admin role for User 1

                );

                context.SaveChanges();
            }
        }
    }
}
