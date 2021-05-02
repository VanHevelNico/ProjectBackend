using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IEvenementRepository {
    Task<List<Evenementen>> GetEvenementen();
    Task<List<Evenementen>> GetEvenementenByData(string startDate, string endDate);
    Task<Evenementen> AddEvent(Evenementen value);
    Task<List<Evenementen>> GetEvenementenByOrganisator(Guid studentenclubId);
    Task UpdateEvenement(Evenementen evenement);
}

public class EvenementRepository : IEvenementRepository {
    private IBackendProjectContext _context;

    public EvenementRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Evenementen>> GetEvenementen() {
        return await _context.Evenementen.Include(s => s.EvenementenStudentenclub).ThenInclude(es => es.Studentenclub).ToListAsync();
    }
    public async Task<List<Evenementen>> GetEvenementenByData(string startDate, string endDate) {
        DateTime start = Convert.ToDateTime(startDate);
        DateTime end = Convert.ToDateTime(endDate);
        return await _context.Evenementen.Where(s => s.Date > start && s.Date < end).Include(s => s.EvenementenStudentenclub).ThenInclude(es => es.Studentenclub).ToListAsync();

    }
    public async Task<List<Evenementen>> GetEvenementenByOrganisator(Guid studentenclubId) {
        return await _context.Evenementen.Where(p => p.EvenementenStudentenclub.Any(l => l.StudentenclubId == studentenclubId)).Include(s => s.EvenementenStudentenclub).ThenInclude(es => es.Studentenclub).ToListAsync();
    }
    public async Task<Evenementen> AddEvent(Evenementen value)
    {
        _context.Evenementen.Add(value);
        int changes = await _context.SaveChangesAsync();
        if (changes > 0)
        {
            return value;
        }
        else
        {
            throw new Exception("event not saved.");
        }
    }
    public async Task UpdateEvenement(Evenementen evenement)
    {
        _context.Evenementen.Update(evenement); // Update de game
        await _context.SaveChangesAsync();
    }
}