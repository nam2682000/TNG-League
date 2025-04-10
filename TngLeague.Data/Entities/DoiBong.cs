using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TngLeague.Domain.Common;
using TngLeague.Domain.Entities;

namespace TngLeague.Domain;

public class DoiBong : BaseEntity<int>
{
    [Required]
    public string TenDoiBong { get; set; } = null!;
    public string LinkAnhDoi { get; set; } = null!;
    public DateTime NgayThanhLap { get; set; } = DateTime.Now;
    public ICollection<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDau>();
    public int GiaiDauId { get; set; }
    public GiaiDau GiaiDau { get; set; } = new GiaiDau();
}