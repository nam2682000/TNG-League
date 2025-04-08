using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TngLeague.Domain.Common;
using TngLeague.Domain.Entities;
using TngLeague.Domain.Enums;

namespace TngLeague.Domain
{
    public class GiaiDau : BaseEntity<int>
    {
        public string TenGiaiDau { get; set; } = string.Empty;
        public string MuaGiai { get; set; } = string.Empty;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public TrangThai? TrangThaiTuyChinh { get; set; }
        public ICollection<DoiBong> DoiBongs { get; set; } = new List<DoiBong>();
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
}