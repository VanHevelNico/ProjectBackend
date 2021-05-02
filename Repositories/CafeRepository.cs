using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface ICafeRepository {
    Task<List<Cafe>> GetCafes();
    Task<Cafe> GetCafeById(Guid cafeId);
    Task<List<Cafe>> GetCafeByCity(int stadId);
    Task<Cafe> AddCafe(Cafe cafe);

}

public class CafeRepository : ICafeRepository {
    private IBackendProjectContext _context;

    public CafeRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Cafe>> GetCafes() {
        return await _context.Cafes.Include(s => s.Studentenclubs).ToListAsync();
    }
    public async Task<List<Cafe>> GetCafeByCity(int stadId) {
        return await _context.Cafes.Where(s => s.StadId == stadId).Include(s => s.Studentenclubs).ToListAsync();
    }
    public async Task<List<Studentenclub>> GetClubs() {
        return await _context.Studentenclubs.ToListAsync(); 
    }
    public async Task<Cafe> AddCafe(Cafe cafe)
    {
        await _context.Cafes.AddAsync(cafe);
        await _context.SaveChangesAsync();
        return cafe;
    }
    public async Task<Cafe> GetCafeById(Guid CafeId) {
        return await _context.Cafes.Where(s => s.CafeId == CafeId).Include(s => s.Studentenclubs).SingleOrDefaultAsync();
    }
}