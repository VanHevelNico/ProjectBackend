using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface ICafeRepository {
    Task<List<Cafe>> GetCafes();
    Task<Cafe> GetCafeById(Guid cafeId);
    Task<Cafe> AddCafe(Cafe cafe);

}

public class CafeRepository : ICafeRepository {
    private IBackendProjectContext _context;

    public CafeRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Cafe>> GetCafes() {
        return await _context.Cafes.ToListAsync();
    }
    public async Task<Cafe> AddCafe(Cafe cafe)
    {
        await _context.Cafes.AddAsync(cafe);
        await _context.SaveChangesAsync();
        return cafe;
    }
    public async Task<Cafe> GetCafeById(Guid CafeId) {
        return await _context.Cafes.Where(s => s.CafeId == CafeId).SingleOrDefaultAsync();
    }
}