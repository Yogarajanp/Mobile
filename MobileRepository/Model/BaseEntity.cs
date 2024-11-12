using System.ComponentModel.DataAnnotations;

namespace MobileRepository.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
