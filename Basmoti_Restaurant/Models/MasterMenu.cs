using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models;

[Table("MasterMenus")]
public partial class MasterMenu : BaseEntity
{
    [Key]
    public int MasterMenuId { get; set; }

    public string MasterMenuName { get; set; } = null!;

    public string MasterMenuUrl { get; set; } = null!;
}
