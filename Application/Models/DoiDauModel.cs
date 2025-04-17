namespace Application.Models;

public class DoiDauThanhVienModel
{
    public DoiDauModel DoiDauModel { get; set; } = new DoiDauModel();
    public List<ThanhVienGiaiDauModel> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDauModel>();
}

public class DoiDauModel
{
    public string TenDoiDau { get; set; } = null!;
    public string LinkAnhDoi { get; set; } = null!;
    public DateTime NgayThanhLap { get; set; } = DateTime.Now;
    public int? GiaiDauId { get; set; }
}
