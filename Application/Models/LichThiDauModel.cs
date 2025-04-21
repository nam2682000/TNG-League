using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class LichThiDauModel
{
    public int GiaiDauVongDauChiTietId { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public string? DiaDiem { get; set; }

    // đội nhà
    public int? DoiDauNhaId { get; set; }
    public string TenDoiNha { get; set; } = string.Empty;
    public string LinkAvatarDoiNha { get; set; } = string.Empty;
    public IFormFile? LinkFileDoiNha { get; set; }
    public int? SoBanGhiDoiNha { get; set; }

    //đội khách
    public int? DoiDauKhachId { get; set; }
    public string TenDoKhach { get; set; } = string.Empty;
    public string LinkAvatarDoiKhach { get; set; } = string.Empty;
    public IFormFile? LinkFileDoiKhach { get; set; }
    public int? SoBanGhiDoiKhach { get; set; }
}

public class TranDauAddModel
{
    public int DoiDauNhaId { get; set; }
    public int DoiDauKhachId { get; set; }
    public int GiaiDauVongDauChiTietId { get; set; }
}


public class TranDauUpdate
{
    public int? SoBanGhiDoiNha { get; set; }
    public int? SoBanGhiDoiKhach { get; set; }
    public int GiaiDauVongDauChiTietId { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
}
public class TranDauModel
{
    public int Id { get; set; }
    public int GiaiDauVongDauChiTietId { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public string? DiaDiem { get; set; }
    public List<ThanhVienSuKienModel> ThanhVienSuKiens { get; set; } = new List<ThanhVienSuKienModel>();
    public List<ThanhVienSuKienModel> ThanhVienGhiBans { get; set; } = new List<ThanhVienSuKienModel>();

    // đội nhà
    public int DoiDauNhaId { get; set; }
    public string TenDoiNha { get; set; } = string.Empty;
    public string LinkAvatarDoiNha { get; set; } = string.Empty;
    public int? SoBanGhiDoiNha { get; set; }
    public List<ThanhVienRaTranModel> ThanhVienRaTranDoiNhas { get; set; } = new List<ThanhVienRaTranModel>();


    //đội khách
    public int DoiDauKhachId { get; set; }
    public string TenDoiKhach { get; set; } = string.Empty;
    public string LinkAvatarDoiKhach { get; set; } = string.Empty;
    public int? SoBanGhiDoiKhach { get; set; }
    public List<ThanhVienRaTranModel> ThanhVienRaTranDoiKhachs { get; set; } = new List<ThanhVienRaTranModel>();

}

public class ThanhVienRaTranModel
{
    public int Id { get; set; }
    public int ThanhVienId { get; set; }
    public int? DoiDauId { get; set; }
    public string HoTen { get; set; } = string.Empty;
    public string TenThiDau { get; set; } = string.Empty;
    public int SoAo { get; set; }
    public int ViTriId { get; set; }
    public string TenViTri { get; set; } = string.Empty;
}
public class ThanhVienSuKienModel {
    public int Id { get; set; }
    public int ThanhVienId { get; set; }
    public int? DoiDauId { get; set; }
    public string HoTen { get; set; } = string.Empty;
    public string TenThiDau { get; set; } = string.Empty;
    public int SoAo { get; set; }
    public bool IsGhiBan { get; set; }
    public bool IsTheDo { get; set; }
    public bool IsTheVang { get; set; }
    public DateTime ThoiGian { get; set; }

}