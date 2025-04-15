using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum TrangThai
{
    [Display(Name = "Chưa bắt đầu")]
    ChuaBatDau,

    [Display(Name = "Đang diễn ra")]
    DangDienRa,

    [Display(Name = "Đã kết thúc")]
    DaKetThuc
}

public enum GioiTinh
{
    [Display(Name = "Nam")]
    Nam,
    [Display(Name = "Nữ")]
    Nu,
}