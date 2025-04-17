using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class GiaiDau : BaseEntity<int>
{
    public string TenGiaiDau { get; set; } = string.Empty;
    public string LinkAvatarGiaiDau { get; set; } = string.Empty;
    public string TenNguoiLienHe { get; set; } = string.Empty;
    public int SoDienThoai { get; set; }
    public string Email { get; set; } = string.Empty;
    public GioiTinh GioiTinh { get; set; } = GioiTinh.Nam;
    public int SoNguoiTrenSan { get; set; }
    public bool IsAuToSetup { get; set; }
    public bool IsMain { get; set; }
    public int SoDoi { get; set; }
    public int? HinhThucThiDauId { get; set; }
    public int SoDoiVaoVongTrong { get; set; }
    public int DiemThang { get; set; }
    public int DiemHoa { get; set; }
    public int DiemThua { get; set; }
    public int SoBangDau { get; set; }
    public int SoVongDau { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public TrangThai? TrangThaiTuyChinh { get; set; }
    public HinhThucThiDau? HinhThucThiDaus { get; set; }
    public ICollection<DoiDau> DoiDaus { get; set; } = new List<DoiDau>();
    public ICollection<BangDau> BangDaus { get; set; } = new List<BangDau>();
    public ICollection<VongDau> VongDaus { get; set; } = new List<VongDau>();

    [NotMapped]
    public TrangThai TrangThai
    {
        get
        {
            if (TrangThaiTuyChinh.HasValue)
                return TrangThaiTuyChinh.Value;

            if (!NgayBatDau.HasValue || !NgayKetThuc.HasValue)
                return TrangThai.ChuaBatDau;

            var now = DateTime.Now;
            if (now < NgayBatDau.Value) return TrangThai.ChuaBatDau;
            if (now >= NgayBatDau.Value && now <= NgayKetThuc.Value) return TrangThai.DangDienRa;
            return TrangThai.DaKetThuc;
        }
        set
        {
            TrangThaiTuyChinh = value;
        }
    }
}
