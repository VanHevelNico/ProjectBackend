using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Cafe {
    public Guid CafeId {get;set;}
    public string Naam {get;set;}
    public string Adres {get;set;}
    public int StadId {get;set;}
    [JsonIgnore]
    public Stad Stad {get;set;}
    //Een cafe kan 1 of meerdere studentenclubs hebben als stamcafe
    public List<Studentenclub> Studentenclubs {get;set;}
}