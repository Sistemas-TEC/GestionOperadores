﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GOAPIGOGO.Models;

public partial class SchedulexOperator
{
    public int idSchedulexOperator { get; set; }

    public DateTime? day { get; set; }

    public TimeSpan? beginningHour { get; set; }

    public TimeSpan? finishingHour { get; set; }

    public int? idOperator { get; set; }

    public virtual Operator idOperatorNavigation { get; set; }
}