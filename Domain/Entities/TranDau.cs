using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class TranDau : BaseEntity<int>
{
    public int? Vong { get; set; }
    public int? GiaiDauId { get; set; }
    public int? GiaiDauBangDauId { get; set; }
    public int? GiaiDauVongDauChiTietId { get; set; }
    public int? DoiDauNhaId { get; set; }
    public int? DoiDauKhachId { get; set; }
    public int? DoiDauThangId { get; set; }
    public int? SoBanGhiDoiNha { get; set; }
    public int? SoBanGhiDoiKhach { get; set; }
    public string? LinkBienBan { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public bool IsLuotVe { get; set; }

    [ForeignKey("DoiDauNhaId")]
    public DoiDau? DoiDauNha { get; set; } 

    [ForeignKey("DoiDauKhachId")]
    public DoiDau? DoiDauKhach { get; set; }

    [ForeignKey("DoiDauThangId")]
    public DoiDau? DoiDauThang { get; set; }
    public GiaiDauBangDau? GiaiDauBangDau { get; set; } 
    public GiaiDauVongDauChiTiet? GiaiDauVongDauChiTiet { get; set; }
    public TrangThai? TrangThaiTuyChinh { get; set; }
    public GiaiDau? GiaiDau { get; set; }
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
    public ICollection<TranDauGhiBan> TranDauGhiBans { get; set; } = new List<TranDauGhiBan>();
    public ICollection<TranDauThePhat> TranDauThePhats { get; set; } = new List<TranDauThePhat>();
}
