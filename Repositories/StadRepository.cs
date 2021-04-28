using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IStadRepository {
    Task<List<Stad>> GetSteden();
}

public class StadRepository : IStadRepository {
    private IBackendProjectContext _context;

    public StadRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Stad>> GetSteden() {
        return await _context.Steden.ToListAsync();
    }
}