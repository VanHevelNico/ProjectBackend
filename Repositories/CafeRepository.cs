using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface ICafeRepository {
    Task<List<Cafe>> GetCafes();
}

public class CafeRepository : ICafeRepository {
    private IBackendProjectContext _context;

    public CafeRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Cafe>> GetCafes() {
        return await _context.Cafes.ToListAsync();
    }
}