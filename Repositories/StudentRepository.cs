using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public interface IStudentRepository {
    Task<List<Student>> GetStudenten();
}

public class StudentRepository : IStudentRepository {
    private IBackendProjectContext _context;
    public StudentRepository(IBackendProjectContext context) {
        _context = context;
    }
    public async Task<List<Student>> GetStudenten() {
        return await _context.Studente.ToListAsync();
    }
}