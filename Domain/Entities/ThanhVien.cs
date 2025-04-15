using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Enums;

namespace Domain;

public class ThanhVien : BaseEntity<int>
{
    [Required]
    public string HoTen { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;
    public string SoCCCD { get; set; } = null!;
    public int Sdt { get; set; }
    
}