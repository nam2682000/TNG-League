using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities;

public class VongDau : BaseEntity<int>
{
    public string TenVongDau { get; set; } = null!;
    public int SoDoi { get; set; }
}
