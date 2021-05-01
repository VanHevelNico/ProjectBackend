using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IEvenementRepository {
    Task<List<Evenementen>> GetEvenementen();
    Task<List<Evenementen>> GetEvenementenByData(DateTime startDate, DateTime endDate);
    Task<List<Evenementen>> GetEvenementenByOrganisator(Guid studentenclubId);
    Task<Evenementen> AddEvent(Evenementen waarde);
}

public class EvenementRepository : IEvenementRepository {
    private IBackendProjectContext _context;

    public EvenementRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Evenementen>> GetEvenementen() {
        return await _context.Evenementen.Include(s => s.Organisators).ToListAsync();
    }
    public async Task<List<Evenementen>> GetEvenementenByData(DateTime startDate, DateTime endDate) {
        return await _context.Evenementen.Where(s => s.Date > startDate && s.Date < endDate).ToListAsync();
    }
    public async Task<List<Evenementen>> GetEvenementenByOrganisator(Guid studentenclubId) {
        return await _context.Evenementen.Where(p => p.Organisators.Any(l => l.StudentenclubId == studentenclubId)).ToListAsync();
    }
    
    public async Task<Evenementen> AddEvent(Evenementen value)
    {
        await _context.Evenementen.AddAsync(value);
        await _context.SaveChangesAsync();
        return value;
    }
}