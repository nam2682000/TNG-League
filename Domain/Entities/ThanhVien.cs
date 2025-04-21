using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class ThanhVien : BaseEntity<int>
{
    public string HoTen { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public string? Email { get; set; } = string.Empty;
    public string SoCCCD { get; set; } = null!;
    public int? Sdt { get; set; }
    public string? LinkAvatar { get; set; }
}