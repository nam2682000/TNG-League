using Domain.Common;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DoiDau : BaseEntity<int>
{
    [Required]
    public string TenDoiDau { get; set; } = null!;
    public string? LinkAvatar { get; set; }
    public string? TenNguoiLienHe { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int? SoDienThoai { get; set; }
    public DateTime? NgayThanhLap { get; set; } = DateTime.Now;
    public int? GiaiDauId { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public ICollection<TranDau> TranDauNha { get; set; } = new List<TranDau>();
    public ICollection<TranDau> TranDauKhach { get; set; } = new List<TranDau>();
    public ICollection<TranDau> TranDauThang { get; set; } = new List<TranDau>();
    public ICollection<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDau>();
}