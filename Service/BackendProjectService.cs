using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public interface IBackendProjectService {
    Task<Cafe> GetCafeById(Guid cafeId);
    Task<List<Cafe>> GetCafes();
    Task<List<Evenementen>> GetEvenementen();
    Task<CafeDTO> AddCafe(CafeDTO cafe);

}
public class BackendProjectService : IBackendProjectService {
    private readonly ICafeRepository _cafeRepository;
    private readonly IEvenementRepository _evenementRepository;
    private readonly IStadRepository _stadRepository;
    private readonly IStudentenclubRepository _studentenclubRepository;
    private readonly IStudentRepository _studentRepository;

    private IMapper _mapper;

    public BackendProjectService(IMapper mapper,ICafeRepository cafeRepository, IEvenementRepository evenementRepository, IStadRepository stadRepository, IStudentenclubRepository studentenclubRepository, IStudentRepository studentRepository) {
        _mapper = mapper;
        _cafeRepository = cafeRepository;
        _evenementRepository = evenementRepository;
        _stadRepository = stadRepository;
        _studentenclubRepository = studentenclubRepository;
        _studentRepository = studentRepository;
    }
    //cafes
    public async Task<Cafe> GetCafeById(Guid cafeId)
    {
        return await _cafeRepository.GetCafeById(cafeId);

    }
    public async Task<List<Cafe>> GetCafes() {
        return await _cafeRepository.GetCafes();
    }
    public async Task<List<Evenementen>> GetEvenementen() {
        return await _evenementRepository.GetEvenementen();
    }

    public async Task<CafeDTO> AddCafe(CafeDTO cafe) {
        try {
            Cafe newCafe = _mapper.Map<Cafe>(cafe);
            await _cafeRepository.AddCafe(newCafe);
            return cafe;
            //Studentenclubs toevoegen            
        }
        catch (System.Exception ex) {
            throw ex;
        }
    }
}