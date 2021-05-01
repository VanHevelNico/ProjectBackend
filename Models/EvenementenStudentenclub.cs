using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EvenementenStudentenclub {
    public Guid EvenementId {get;set;}
    public Guid StudentenclubId {get;set;}
    public Studentenclub Studentenclub {get;set;}
    public Evenementen Evenementen {get;set;}
}
