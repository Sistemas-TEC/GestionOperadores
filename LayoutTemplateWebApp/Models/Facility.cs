﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Models;

public partial class Facility
{
    public int IdFacilities { get; set; }

    public int? Capacity { get; set; }

    public int? IdUser { get; set; }

    public virtual ICollection<Classroom> Classroom { get; set; } = new List<Classroom>();

    public virtual User IdUserNavigation { get; set; }

    public virtual ICollection<Laboratory> Laboratory { get; set; } = new List<Laboratory>();

    public virtual ICollection<SchedulexFacility> SchedulexFacility { get; set; } = new List<SchedulexFacility>();
}