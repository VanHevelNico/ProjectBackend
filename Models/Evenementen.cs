using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Evenementen {
    public Guid EvenementenId {get;set;}
    public string Naam {get;set;}
    public string Beschrijving {get;set;}
    public string LinkEvent {get;set;}
    public DateTime Date {get;set;}
    //public List<Studentenclub> Organisators {get;set;}
    [JsonPropertyName("Organisators")]
    public List<EvenementenStudentenclub> EvenementenStudentenclub { get; set; }
}