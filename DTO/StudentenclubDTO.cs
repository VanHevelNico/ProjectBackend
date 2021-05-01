using System;
using System.Collections.Generic;

public class StudentenclubDTO
{
    public Guid StudentenclubId{get;set;}
    public string Naam {get;set;}
    public string Beschrijving {get;set;}
    public int Oprichtingsjaar {get;set;}
    public int StadId {get;set;}
    //public Stad Stad {get;set;}
    public Guid CafeId {get;set;}
    //public Cafe Cafe {get;set;}
    
    //public List<Student> Leden {get;} = new List<Student>();
    //public List<Evenementen> Evenementen {get;} = new List<Evenementen>();
}