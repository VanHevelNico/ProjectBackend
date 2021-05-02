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
    
    [JsonIgnore]
    public List<EvenementenStudentenclub> EvenementenStudentenclub { get; set; }

}