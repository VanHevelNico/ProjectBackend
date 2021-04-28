using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IEvenementRepository {
    Task<List<Evenementen>> GetEvenementen();
}

public class EvenementRepository : IEvenementRepository {
    private IBackendProjectContext _context;

    public EvenementRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Evenementen>> GetEvenementen() {
        return await _context.Evenementen.ToListAsync();
    }
}