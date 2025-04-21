using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class ThanhVienGiaiDauModel
{
    //ThanhVienGiaiDau
    public int? Id { get; set; }
    public string TenThiDau { get; set; } = null!;
    public int SoAo { get; set; }
    public int? ThanhVienId { get; set; }
    public int? GiaiDauId { get; set; }
    public int? DoiDauId { get; set; }
    public int? ViTriId { get; set; }
    public int? VaiTroId { get; set; }


    //ThanhVien 
    public string HoTen { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public string Email { get; set; } = string.Empty;
    public string SoCCCD { get; set; } = null!;
    public int Sdt { get; set; }
    public string? LinkAvatar { get; set; }
    public IFormFile? FileAvatar { get; set; }
    public bool IsNew { get; set; }
    public bool IsChanged { get; set; }
}