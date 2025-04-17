using Domain.Common;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class DoiBong : BaseEntity<int>
{
    [Required]
    public string TenDoiBong { get; set; } = null!;
    public string LinkAnhDoi { get; set; } = null!;
    public DateTime NgayThanhLap { get; set; } = DateTime.Now;
    public ICollection<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDau>();
    public int? GiaiDauId { get; set; }
    public GiaiDau? GiaiDau { get; set; }
}