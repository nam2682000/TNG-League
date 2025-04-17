using Domain.Common;

namespace Domain.Entities;

public class GiaiDauVongDauChiTiet : BaseEntity<int>
{
    public string TenVongDau { get; set; } = string.Empty;
    public int? GiaiDauVongDauId { get; set; }
    public GiaiDauVongDau? GiaiDau { get; set; }
}
