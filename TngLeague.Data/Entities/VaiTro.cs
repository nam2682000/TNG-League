using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class VaiTro : BaseEntity<int>
{
    public string TenVaiTro { get; set; } = null!;
}
