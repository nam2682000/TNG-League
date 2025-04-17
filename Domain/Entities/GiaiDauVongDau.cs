using Domain.Common;

namespace Domain.Entities;

public class GiaiDauVongDau : BaseEntity<int>
{
    public int? VongDauId { get; set; }
    public int? GiaiDauId { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsKnockout { get; set; }
    public int Order { get; set; }
    public GiaiDau? GiaiDau { get; set; }
    public VongDau? VongDau { get; set; }
    public List<GiaiDauVongDauChiTiet> GiaiDauVongDauChiTiets { get; set; } = new List<GiaiDauVongDauChiTiet>();
}
