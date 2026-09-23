using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterWorkingHours : BaseEntity
{
    [Key]
    public int MasterWorkingHoursId { get; set; }

    public string MasterWorkingHoursName { get; set; } = null!;

    public string MasterWorkingHoursTimeFormTo { get; set; } = null!;
}
