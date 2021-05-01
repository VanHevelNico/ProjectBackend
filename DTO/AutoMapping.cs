using System;
using System.Collections.Generic;
using AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping() {

        CreateMap<CafeDTO, Cafe>();
        CreateMap<EvenementenDTO, Evenementen>();
        CreateMap<StudentenclubDTO, Studentenclub>();
        
    }
}
