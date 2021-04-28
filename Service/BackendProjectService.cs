using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBackendProjectService {
    Task<List<Cafe>> GetCafes();
}
public class BackendProjectService : IBackendProjectService {
    private readonly ICafeRepository _cafeRepository;
    private readonly IEvenementRepository _evenementRepository;
    private readonly IStadRepository _stadRepository;
    private readonly IStudentenclubRepository _studentenclubRepository;
    private readonly IStudentRepository _studentRepository;

    public BackendProjectService(ICafeRepository cafeRepository, IEvenementRepository evenementRepository, IStadRepository stadRepository, IStudentenclubRepository studentenclubRepository, IStudentRepository studentRepository) {
        _cafeRepository = cafeRepository;
        _evenementRepository = evenementRepository;
        _stadRepository = stadRepository;
        _studentenclubRepository = studentenclubRepository;
        _studentRepository = studentRepository;
    }

    public async Task<List<Cafe>> GetCafes() {
        return await _cafeRepository.GetCafes();
    }
}