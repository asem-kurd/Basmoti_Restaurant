using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;


// for menu page (filter)
public partial class MasterItemMenu:BaseEntity
{
    [Key]
    public int MasterItemMenuId { get; set; }

    public string MasterItemMenuTitle { get; set; } = null!;

    public string MasterItemMenuBreef { get; set; } = null!;

    public string MasterItemMenuDesc { get; set; } = null!;

    public double MasterItemMenuPrice { get; set; }

    public string MasterItemMenuImageUrl { get; set; } = null!;

    public DateTime MasterItemMenuDate { get; set; }


    // many side

    public int MasterCategoryMenuId { get; set; }
    public virtual MasterCategoryMenu MasterCategoryMenu { get; set; } = null!;
}
