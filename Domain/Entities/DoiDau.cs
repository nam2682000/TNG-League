using Domain.Common;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DoiDau : BaseEntity<int>
{
    [Required]
    public string TenDoiDau { get; set; } = null!;
    public string LinkAnhDoi { get; set; } = null!;
    public DateTime NgayThanhLap { get; set; } = DateTime.Now;
    public int? GiaiDauId { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public ICollection<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDau>();
}