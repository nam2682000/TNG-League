using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class BangDau : BaseEntity<int>
{
    public string TenBangDau { get; set; } = null!;
}
