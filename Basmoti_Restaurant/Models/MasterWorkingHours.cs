using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class MasterWorkingHours : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterWorkingHoursId { get; set; }


    [Display(Name = "Day Name")]
    public string MasterWorkingHoursDayName { get; set; } = null!;   
    
    [Display(Name = "Is Closed")]
    public bool MasterWorkingHoursIsClosed { get; set; }

    [Display(Name = "Open Time")]
    public string MasterWorkingHoursOpenTime { get; set; } = null!;

    [Display(Name = "Close Time")]
    public string MasterWorkingHoursCloseTime { get; set; } = null!;
}
