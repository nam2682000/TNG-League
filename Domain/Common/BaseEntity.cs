using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
