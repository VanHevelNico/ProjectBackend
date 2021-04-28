using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Cafe {
    public Guid CafeId {get;set;}
    public string Naam {get;set;}
    public string Adres {get;set;}
    public int StadId {get;set;}
    public Stad Stad {get;set;}
    //Een cafe kan 1 of meerdere studentenclubs hebben als stamcafe
    public List<Studentenclub> Studentenclubs {get;} = new List<Studentenclub>();
}