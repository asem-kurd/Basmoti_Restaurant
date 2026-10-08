using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basmoti_Restaurant.Models;

[Table("MasterMenus")]
public partial class MasterMenu : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterMenuId { get; set; }

    [Display(Name = "Name")]
    public string MasterMenuName { get; set; } = null!;

    [Display(Name = "URL")]
    public string MasterMenuUrl { get; set; } = null!;
}
