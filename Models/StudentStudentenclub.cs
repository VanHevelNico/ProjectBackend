using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class StudentStudentenclub {
    public Guid ClubsStudentenclubId {get;set;}
    public Guid LedenStudentId {get;set;}
    public Student Student {get;set;}
    public Studentenclub Studentenclub {get;set;}
}