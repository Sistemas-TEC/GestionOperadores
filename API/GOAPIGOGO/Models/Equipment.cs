﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GOAPIGOGO.Models;

public partial class Equipment
{
    public int idEquipment { get; set; }

    public bool? availability { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public int? idUser { get; set; }

    public string condition { get; set; }

    public virtual ICollection<SchedulexEquipment> SchedulexEquipments { get; set; } = new List<SchedulexEquipment>();

    public virtual User idUserNavigation { get; set; }
}