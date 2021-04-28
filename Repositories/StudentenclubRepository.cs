using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IStudentenclubRepository {
    Task<List<Studentenclub>> GetStudentenclubs();
}

public class StudentenclubRepository : IStudentenclubRepository {
    private IBackendProjectContext _context;

    public StudentenclubRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Studentenclub>> GetStudentenclubs() {
        return await _context.Studentenclubs.ToListAsync();
    }
}