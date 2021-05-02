using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public interface IBackendProjectService {
    Task<Cafe> GetCafeById(Guid cafeId);
    Task<List<Cafe>> GetCafeByCityId(int cityId);
    Task<List<Cafe>> GetCafes();
    Task<List<Evenementen>> GetEvenementen();
    Task<List<Evenementen>> GetEvenementenByDate(DateTime startDate, DateTime endDate);
    Task<CafeDTO> AddCafe(CafeDTO cafe);
    Task<Evenementen> AddEvent(EvenementenAddDTO waarde);
    Task<StudentenclubDTO> AddStudentenclub(StudentenclubDTO waarde);
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
    public async Task<List<Cafe>> GetCafes() {
        return await _cafeRepository.GetCafes();
    }
    public async Task<Cafe> GetCafeById(Guid cafeId)
    {
        return await _cafeRepository.GetCafeById(cafeId);

    }
    public async Task<List<Cafe>> GetCafeByCityId(int cityId) {
        return await _cafeRepository.GetCafeByCity(cityId);
    }
    public async Task<List<Evenementen>> GetEvenementen() {
        return await _evenementRepository.GetEvenementen();
    }
    public async Task<List<Evenementen>> GetEvenementenByDate(DateTime startDate, DateTime endDate) {
        return await _evenementRepository.GetEvenementenByData(startDate, endDate);
    }

    public async Task<CafeDTO> AddCafe(CafeDTO cafe) {
        try {
            Cafe newCafe = _mapper.Map<Cafe>(cafe);
            await _cafeRepository.AddCafe(newCafe);
            return cafe;
        }
        catch (System.Exception ex) {
            throw ex;
        }
    }    
    public async Task<Evenementen> AddEvent(EvenementenAddDTO waarde) {
        try {
            Evenementen newEvent = _mapper.Map<Evenementen>(waarde);
            newEvent.EvenementenStudentenclub = new List<EvenementenStudentenclub>();
            foreach (StudentenclubDTO stu in waarde.Organisators)
            {
                newEvent.EvenementenStudentenclub.Add(new EvenementenStudentenclub() { StudentenclubId = stu.StudentenclubId });
            }
            
            return await _evenementRepository.AddEvent(newEvent);
        }
        catch (System.Exception ex) {
            throw ex;
        }
    }

        public async Task<StudentenclubDTO> AddStudentenclub(StudentenclubDTO waarde) {
        try {
            Studentenclub newStudentClub = _mapper.Map<Studentenclub>(waarde);
            await _studentenclubRepository.AddStudentenclub(newStudentClub);
            return waarde;
        }
        catch (System.Exception ex) {
            throw ex;
        }
    }
}