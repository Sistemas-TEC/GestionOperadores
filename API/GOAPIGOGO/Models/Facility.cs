﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GOAPIGOGO.Models;

public partial class Facility
{
    public int idFacilities { get; set; }

    public int? capacity { get; set; }

    public int? idUser { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Laboratory> Laboratories { get; set; } = new List<Laboratory>();

    public virtual ICollection<SchedulexFacility> SchedulexFacilities { get; set; } = new List<SchedulexFacility>();

    public virtual User idUserNavigation { get; set; }
}