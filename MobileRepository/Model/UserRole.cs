using System.ComponentModel.DataAnnotations;

namespace MobileRepository.Model
{
    public class UserRole
    {
        [Key]
        public long Id;
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
