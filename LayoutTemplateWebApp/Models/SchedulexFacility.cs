﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Models;

public partial class SchedulexFacility
{
    public int IdSchedulexFacility { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? BeginningHour { get; set; }

    public TimeSpan? FinishingHour { get; set; }

    public int? IdFacilities { get; set; }

    public virtual Facility IdFacilitiesNavigation { get; set; }
}