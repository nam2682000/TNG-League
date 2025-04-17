using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class VongDau : BaseEntity<int>
{
    public string TenVongDau { get; set; } = null!;
    public int SoDoi { get; set; }
    public LoaiVong LoaiVong { get; set; }
}
