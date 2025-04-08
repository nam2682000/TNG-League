using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

class HinhThucThiDau : BaseEntity<int>
{
    public string TenHinhThuc { get; set; } = null!;
}
