using System.ComponentModel.DataAnnotations;
using TngLeague.Domain.Common;

namespace TngLeague.Domain;

public class ThanhVien : BaseEntity<int>
{

    [Required]
    public string TenThiDau { get; set; } = null!;
    public int SoAo { get; set; }
    public string HoTen { get; set; } = string.Empty;
    public DateTime NgaySinh { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;
    public int DoiBongId { get; set; }
    public DoiBong DoiBongs { get; set; } = new DoiBong();
}