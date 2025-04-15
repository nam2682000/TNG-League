using Domain.Common;

namespace Domain.Entities;

public class ThanhVienGiaiDau : BaseEntity<int>
{
    public string TenThiDau { get; set; } = null!;
    public int SoAo { get; set; }
    public int? ThanhVienId { get; set; }
    public int? GiaiDauId { get; set; }
    public int? DoiBongId { get; set; }
    public ThanhVien? ThanhVien { get; set; }
    public GiaiDau? GiaiDau { get; set; } 
    public DoiBong? DoiBongs { get; set; }
}
