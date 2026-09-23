using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterWorkingHours : BaseEntity
{
    [Key]
    public int MasterWorkingHoursId { get; set; }

    public string MasterWorkingHoursDayName { get; set; } = null!;   

    public bool MasterWorkingHoursIsClosed { get; set; }

    public string MasterWorkingHoursOpenTime { get; set; }
    public string MasterWorkingHoursCloseTime { get; set; }
}
