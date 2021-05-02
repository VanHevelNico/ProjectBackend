using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IStudentenclubRepository {
    Task<List<Studentenclub>> GetStudentenclubs();
    Task<Studentenclub> AddStudentenclub(Studentenclub waarde);
    Task<List<EvenementenStudentenclub>> GetOrganisatorsOfEvent(Guid evenementId);
}

public class StudentenclubRepository : IStudentenclubRepository {
    private IBackendProjectContext _context;

    public StudentenclubRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Studentenclub>> GetStudentenclubs() {
        return await _context.Studentenclubs.ToListAsync();
    }
    public async Task<List<EvenementenStudentenclub>> GetOrganisatorsOfEvent(Guid evenementId)
    {
        return await _context.EvenementenStudentenclub.Where(es => es.EvenementenId == evenementId).Include(es => es.Studentenclub).ToListAsync();
    }
    public async Task<Studentenclub> AddStudentenclub(Studentenclub value)
    {
        await _context.Studentenclubs.AddAsync(value);
        await _context.SaveChangesAsync();
        return value;
    }
}