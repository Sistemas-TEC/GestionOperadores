﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GOAPIGOGO.Models;

public partial class SchedulexEquipment
{
    public int idSchedulexEquipment { get; set; }

    public DateTime? initialDate { get; set; }

    public DateTime? finalDate { get; set; }

    public TimeSpan? beginningHour { get; set; }

    public TimeSpan? finishingHour { get; set; }

    public int? idEquipment { get; set; }

    public virtual Equipment idEquipmentNavigation { get; set; }
}