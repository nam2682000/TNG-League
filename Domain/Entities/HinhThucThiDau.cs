using Domain.Common;

namespace Domain.Entities;

public class HinhThucThiDau : BaseEntity<int>
{
    public string TenHinhThuc { get; set; } = null!;
    public string Mota { get; set; } = string.Empty;
}
