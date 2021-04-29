using System;
using System.Collections.Generic;
using AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping() {

        CreateMap<CafeDTO, Cafe>();
        
    }
}
