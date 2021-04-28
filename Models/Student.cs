using System;
using System.Collections.Generic;

public class Student {
    public Guid StudentId {get;set;}
    public string Naam {get;set;}
    public DateTime GeboorteDatum {get;set;}
    public List<Studentenclub> Clubs {get;} = new List<Studentenclub>();
}