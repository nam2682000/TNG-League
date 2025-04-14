using System.ComponentModel.DataAnnotations;
using TngLeague.Domain.Common;

namespace TngLeague.Domain.Entities;

public class VongDau : BaseEntity<int>
{
    public string TenVongDau { get; set; } = null!;
    public int SoLuongDoi { get; set; }
}
