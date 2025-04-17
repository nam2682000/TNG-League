using Application.Interfaces;
using Application.Models.GiaiDau;
using AutoMapper;
using Domain;

namespace Application.Services
{
    public class GiaiDauService : IGiaiDauService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GiaiDauService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> SuaGiaiDau(int id, GiaiDauModel model)
        {
            var giaiDau = await _context.GiaiDaus.FindAsync(id);
            if (giaiDau is null)
                throw new Exception("Không tìm thấy giải đấu");
            _mapper.Map(model, giaiDau);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> TaoGiaiDau(GiaiDauModel model)
        {
            var giaiDau = _mapper.Map<GiaiDau>(model);
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
