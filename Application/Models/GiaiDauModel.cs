using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class GiaiDauModel
{
    public int? Id { get; set; }
    public string TenGiaiDau { get; set; } = string.Empty;
    public string LinkAvatar { get; set; } = string.Empty;
    public IFormFile? FileAvatar { get; set; }
    public string TenNguoiLienHe { get; set; } = string.Empty;
    public int SoDienThoai { get; set; }
    public string Email { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; } = GioiTinh.Nam;
    public int SoDoi { get; set; }
    public int SoNguoiTrenSan { get; set; }
    public bool IsAuToSetup { get; set; }
    public int? HinhThucThiDauId { get; set; }
    public int SoDoiVaoVongTrong { get; set; }
    public int DiemThang { get; set; }
    public int DiemHoa { get; set; }
    public int DiemThua { get; set; }
    public int SoBangDau { get; set; }
    public int SoVongDau { get; set; }
    public TrangThai TrangThai { get; set; }
    public TrangThai? TrangThaiTuyChinh { get; set; }
    public bool IsMain { get; set; }
}
