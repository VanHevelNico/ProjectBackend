using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public interface IBackendProjectService {
    Task<Cafe> GetCafeById(Guid cafeId);
    Task<List<Cafe>> GetCafeByCityId(int cityId);
    Task<List<Cafe>> GetCafes();
    Task<List<Evenementen>> GetEvenementen();
    Task<List<Evenementen>> GetEvenementenByDate(string startDate, string endDate);
    Task<CafeDTO> AddCafe(CafeDTO cafe);
    Task<Evenementen> AddEvent(EvenementenAddDTO waarde);
    Task<StudentenclubDTO> AddStudentenclub(StudentenclubDTO waarde);
    Task<List<Evenementen>> GetEventByStudentClub(Guid StudentenClub);
    Task<List<Studentenclub>> GetClubs();
    Task UpdateEvenement(EvenementenUpdateDTO evenement);
}
public class BackendProjectService : IBackendProjectService {
    private readonly ICafeRepository _cafeRepository;
    private readonly IEvenementRepository _evenementRepository;
    private readonly IStadRepository _stadRepository;
    private readonly IStudentenclubRepository _studentenclubRepository;

    private IMapper _mapper;

    public BackendProjectService(IMapper mapper,ICafeRepository cafeRepository, IEvenementRepository evenementRepository, IStadRepository stadRepository, IStudentenclubRepository studentenclubRepository) {
        _mapper = mapper;
        _cafeRepository = cafeRepository;
        _evenementRepository = evenementRepository;
        _stadRepository = stadRepository;
        _studentenclubRepository = studentenclubRepository;
    }
    //cafes
    public async Task<List<Cafe>> GetCafes() {
        return await _cafeRepository.GetCafes();
    }
    public async Task<List<Studentenclub>> GetClubs() {
        return await _studentenclubRepository.GetStudentenclubs();
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
    public async Task<List<Evenementen>> GetEvenementenByDate(string startDate, string endDate) {
        return await _evenementRepository.GetEvenementenByData(startDate, endDate);
    }
    public async Task<List<Evenementen>> GetEventByStudentClub(Guid StudentenClub) {
        return await _evenementRepository.GetEvenementenByOrganisator(StudentenClub);
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

    public async Task UpdateEvenement(EvenementenUpdateDTO evenement) 
    {
        Evenementen oldEvenement = _mapper.Map<Evenementen>(evenement);
        await _evenementRepository.UpdateEvenement(oldEvenement);
    }
}