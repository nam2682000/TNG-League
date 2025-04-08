using System.ComponentModel.DataAnnotations.Schema;
using TngLeague.Domain.Common;
using TngLeague.Domain.Enums;

namespace TngLeague.Domain.Entities;

public class TranDau : BaseEntity<int>
{
    public int GiaiDauId { get; set; }
    public int GiaiDauBangDauId { get; set; }
    public int GiaiDauVongDauId { get; set; }
    public int DoiBong1Id { get; set; }
    public int DoiBong2Id { get; set; }
    public int? DoiBongThangId { get; set; }
    public string DiaDiem { get; set; } = string.Empty;
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }

    [ForeignKey("DoiBong1Id")]
    public DoiBong DoiBong1 { get; set; } = null!;

    [ForeignKey("DoiBong2Id")]
    public DoiBong DoiBong2 { get; set; } = null!;

    [ForeignKey("DoiBongThangId")]
    public DoiBong? DoiBongThang { get; set; } = null!;
    public GiaiDauBangDau GiaiDauBangDau { get; set; } = null!;
    public GiaiDauVongDau GiaiDauVongDau { get; set; } = null!;
    public TrangThai? TrangThaiTuyChinh { get; set; }
    public GiaiDau GiaiDau { get; set; } = null!;

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
