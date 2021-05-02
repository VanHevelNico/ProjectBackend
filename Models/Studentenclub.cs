using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Studentenclub
{
    public Guid StudentenclubId{get;set;}
    public string Naam {get;set;}
    public string Beschrijving {get;set;}
    public int Oprichtingsjaar {get;set;}
    public int StadId {get;set;}
    //public Stad Stad {get;set;}
    public Guid CafeId {get;set;}
    //public Cafe Cafe {get;set;}
    
    //Veel op veel met studenten (1 studentenclub heeft meerdere studenten als lid, 1 student kan lid zijn van meerdere clubs)
    public List<Student> Leden {get;set;} = new List<Student>();
    //public List<Evenementen> Evenementen {get;set;} = new List<Evenementen>();

    [JsonIgnore]
    public List<EvenementenStudentenclub> EvenementenStudentenclub { get; set; }

}