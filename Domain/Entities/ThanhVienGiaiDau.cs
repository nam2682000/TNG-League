using Domain.Common;

namespace Domain.Entities;

public class ThanhVienGiaiDau : BaseEntity<int>
{
    public string TenThiDau { get; set; } = null!;
    public int SoAo { get; set; }
    public int? ThanhVienId { get; set; }
    public int? GiaiDauId { get; set; }
    public int? DoiDauId { get; set; }
    public int? ViTriId { get; set; }
    public int? VaiTroId { get; set; }
    public VaiTro? VaiTro { get; set; }
    public ViTri? ViTri { get; set; }
    public ThanhVien? ThanhVien { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public DoiDau? DoiDaus { get; set; }
}
