using System;
using System.Collections.Generic;

    public class EvenementenDTO
    {
        public Guid EvenementenId {get;set;}
        public string Naam {get;set;}
        public string Beschrijving {get;set;}
        public string LinkEvent {get;set;}
        public DateTime Date {get;set;}
        public List<Studentenclub> Organisators {get;} = new List<Studentenclub>();
       
    }
