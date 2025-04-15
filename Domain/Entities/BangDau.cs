using Domain.Common;

namespace Domain.Entities;

public class BangDau : BaseEntity<int>
{
    public string TenBangDau { get; set; } = null!;
}
