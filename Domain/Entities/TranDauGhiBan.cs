using Domain.Common;

namespace Domain.Entities;

public class TranDauGhiBan : BaseEntity<int>
{
    public int? TranDauId { get; set; }
    public int? ThanhVienGiaiDauId { get; set; }
    public DateTime ThoiGianGhiBan { get; set; }
    public ThanhVienGiaiDau? ThanhVienGiaiDau { get; set; }
    public TranDau? TranDau { get; set; }
}
