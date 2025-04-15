using Domain.Common;

namespace Domain.Entities;

public class TranDauThePhat : BaseEntity<int>
{
    public int? TranDauId { get; set; }
    public int? ThanhVienGiaiDauId { get; set; }
    public bool IsTheDo { get; set; }
    public bool IsTheVang { get; set; }
    public DateTime ThoiGianPhat { get; set; }
    public ThanhVienGiaiDau? ThanhVienGiaiDau { get; set; } 
    public TranDau? TranDau { get; set; } 
}

