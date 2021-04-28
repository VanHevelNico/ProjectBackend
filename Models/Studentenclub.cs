using System;
using System.Collections.Generic;

public class Studentenclub
{
    public Guid StudentenclubId{get;set;}
    public string Naam {get;set;}
    public string Beschrijving {get;set;}
    public int Oprichtingsjaar {get;set;}
    public int StadId {get;set;}
    public Stad Stad {get;set;}
    public int CafeId {get;set;}
    public Cafe Cafe {get;set;}
    
    //Veel op veel met studenten (1 studentenclub heeft meerdere studenten als lid, 1 student kan lid zijn van meerdere clubs)
    public List<Student> Leden {get;} = new List<Student>();
    public List<Evenementen> Evenementen {get;} = new List<Evenementen>();
    //evt image
}