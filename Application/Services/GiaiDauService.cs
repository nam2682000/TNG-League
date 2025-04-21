using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class GiaiDauService : IGiaiDauService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public GiaiDauService(AppDbContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<List<GiaiDauModel>> GetAllGiaiDau()
        {
            var data = await _context.GiaiDaus.AsNoTracking().ToListAsync();
            var result = _mapper.Map<List<GiaiDauModel>>(data);
            return result;
        }

        public async Task<GiaiDauModel> GetGiaiDau(int id)
        {
            var data = await _context.GiaiDaus.FindAsync(id);
            if (data == null)
                throw new Exception("Không tìm thấy giải đấu");

            return _mapper.Map<GiaiDauModel>(data);
        }

        public async Task<bool> SuaGiaiDau(int id, GiaiDauModel model)
        {
            var giaiDau = await _context.GiaiDaus.FindAsync(id);
            if (giaiDau == null)
                throw new Exception("Không tìm thấy giải đấu");

            _mapper.Map(model, giaiDau);

            if (model.FileAvatar != null)
            {
                // Lưu file và thay thế file cũ nếu có
                string link = await _fileService.SaveFileAsync(model.FileAvatar, "images", giaiDau.LinkAvatar);
                giaiDau.LinkAvatar = link;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> TaoGiaiDau(GiaiDauModel model)
        {
            
            var giaiDau = _mapper.Map<GiaiDau>(model);
            if (model.FileAvatar is not null)
            {
                string link = await _fileService.SaveFileAsync(model.FileAvatar, "images");
                giaiDau.LinkAvatar = link;
            }
            _context.GiaiDaus.Add(giaiDau);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> XoaGiaiDau(int id)
        {
            var giaiDau = await _context.GiaiDaus.FindAsync(id);
            if (giaiDau is null)
                throw new Exception("Không tìm thấy giải đấu");
            _context.GiaiDaus.Remove(giaiDau);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
