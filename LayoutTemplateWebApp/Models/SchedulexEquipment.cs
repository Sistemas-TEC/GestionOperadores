﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Models;

public partial class SchedulexEquipment
{
    public int IdSchedulexEquipment { get; set; }

    public DateTime? InitialDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public TimeSpan? BeginningHour { get; set; }

    public TimeSpan? FinishingHour { get; set; }

    public int? IdEquipment { get; set; }

    public virtual Equipment IdEquipmentNavigation { get; set; }
}