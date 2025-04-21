using Application.Models;

namespace Application.Interfaces;
public interface ITranDauService
{
    Task<List<LichThiDauModel>> GetLichThiDau(int idGiaiDau, int? vongDauId = null, int? doiDauId = null);
    Task<bool> ThemTranDau(int idGiaiDau ,List<TranDauAddModel> models);
    Task<TranDauModel> ChiTietTranDau(int id);
    Task<bool> CapNhatChiTietTranDau(int id, TranDauUpdate model);
    Task<bool> ThemSuKien(int idTranDau, ThanhVienSuKienModel model);
    Task<bool> XoaSuKien(bool IsGhiBan,bool IsThePhat,int id);
    Task<bool> SuaSuKien(int id, ThanhVienSuKienModel model);
    Task<bool> XoaTranDau(int id);
}
