using System;
using System.Collections.Generic;

    public class CafeDTO
    {
        public Guid CafeId {get;set;}
        public string Naam {get;set;}
        public string Adres {get;set;}
        public int StadId {get;set;}
        public List<StudentenclubDTO> Studentenclubs {get;set;}
       
    }
