using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class ThanhVienGiaiDau : BaseEntity<int>
{
    public int ThanhVienId { get; set; }
    public int GiaiDauId { get; set; }
    public ThanhVien ThanhVien { get; set; } = null!;
    public GiaiDau GiaiDau { get; set; } = null!;

}
