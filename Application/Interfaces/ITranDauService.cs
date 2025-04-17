using Application.Models;

namespace Application.Interfaces;
public interface ITranDauService
{
    Task<List<LichThiDauModel>> GetLichThiDau(int? vongDauId, int? doiDauId);
    Task<bool> ThemTranDau(List<TranDauAddModel> models);
    Task<TranDauModel> ChiTietTranDau(int id);
    Task<bool> CapNhatChiTietTranDau(int id, TranDauUpdate model);
    Task<bool> ThemSuKien(int idTranDau, ThanhVienSuKienModel model);
    Task<bool> XoaSuKien(int id);
    Task<bool> SuaSuKien(int id, ThanhVienSuKienModel model);
    Task<bool> XoaTranDau(int id);
}
