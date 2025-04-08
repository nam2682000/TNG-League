using System.ComponentModel.DataAnnotations;

namespace TngLeague.Domain.Enums;

public enum TrangThai
{
    [Display(Name = "Chưa bắt đầu")]
    ChuaBatDau,

    [Display(Name = "Đang diễn ra")]
    DangDienRa,

    [Display(Name = "Đã kết thúc")]
    DaKetThuc
}
