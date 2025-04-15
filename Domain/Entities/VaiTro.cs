using Domain.Common;

namespace Domain.Entities;

public class VaiTro : BaseEntity<int>
{
    public string TenVaiTro { get; set; } = null!;
    public string Mota { get; set; } = string.Empty;
}
