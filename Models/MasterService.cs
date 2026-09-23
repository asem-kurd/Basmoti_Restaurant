using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;



// about page (Our Services)
public partial class MasterService : BaseEntity
{
    [Key]
    public int MasterServicesId { get; set; }

    public string MasterServicesTitle { get; set; } = null!;

    public string MasterServicesDesc { get; set; } = null!;

    public string MasterServicesImage { get; set; } = null!;
}
