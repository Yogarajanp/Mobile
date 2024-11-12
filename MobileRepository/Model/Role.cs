using System.ComponentModel.DataAnnotations;

namespace MobileRepository.Model
{
    public class Role
    {
        [Key]
        public long Id;

        public string RoleName { get; set; }

    }
}
