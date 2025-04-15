using Domain.Common;

namespace Domain.Entities;

public class ViTri:BaseEntity<int>
{
    public string TenViTri { get; set; } = null!;
    public string MoTa { get; set; } = string.Empty;
}
