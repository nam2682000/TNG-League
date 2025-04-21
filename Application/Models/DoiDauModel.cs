using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class DoiDauThanhVienModel
{
    public DoiDauModel DoiDauModel { get; set; } = new DoiDauModel();
    public List<ThanhVienGiaiDauModel> ThanhVienGiaiDaus { get; set; } = new List<ThanhVienGiaiDauModel>();
}

public class DoiDauModel
{
    public int? Id { get; set; }
    public string TenDoiDau { get; set; } = null!;
    public string TenNguoiLienHe { get; set; } = string.Empty;
    public string? Email { get; set; }
    public int? SoDienThoai { get; set; }
    public int? SoThanhVien { get; set; }
    public int? SoTranThang { get; set; }
    public int? SoTranHoa { get; set; }
    public int? SoTranThua { get; set; }
    public int? SoTranDaChoi { get; set; }
    public string? LinkAvatar { get; set; }
    public IFormFile? FileAvatar { get; set; } 
    public DateTime? NgayThanhLap { get; set; } = DateTime.Now;
    public int? GiaiDauId { get; set; }
}


