using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class EvenementenStudentenclub {
    [JsonIgnore]
    public Guid EvenementenId {get;set;}
    public Guid StudentenclubId {get;set;}
    public Studentenclub Studentenclub {get;set;}
}

