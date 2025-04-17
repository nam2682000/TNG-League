using Domain.Enums;

namespace Application.Models.GiaiDau;

public class GiaiDauModel
{
    public string TenGiaiDau { get; set; } = string.Empty;
    public string LinkAvatarGiaiDau { get; set; } = string.Empty;
    public string TenNguoiLienHe { get; set; } = string.Empty;
    public int SoDienThoai { get; set; }
    public string Email { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; } = GioiTinh.Nam;
    public int SoNguoiTrenSan { get; set; }
    public bool IsAuToSetup { get; set; }
    public int SoDoi { get; set; }
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
