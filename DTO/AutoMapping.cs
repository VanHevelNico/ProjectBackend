using System;
using System.Collections.Generic;
using AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping() {

        CreateMap<CafeDTO, Cafe>();
        CreateMap<Cafe, CafeDTO>();
        CreateMap<Studentenclub,StudentenclubDTO>();
        CreateMap<StudentenclubDTO,Studentenclub>();

        CreateMap<Evenementen, EvenementenAddDTO>();
        CreateMap<EvenementenAddDTO, Evenementen>();
        
    }
}
