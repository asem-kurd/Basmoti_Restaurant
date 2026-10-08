using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;



// for menu page (filter)


// one side
public partial class MasterCategoryMenu : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterCategoryMenuId { get; set; }

    [Display(Name = "Name")]
    public string MasterCategoryMenuName { get; set; } = null!;

    [Display(Name = "Item Menu")]
    public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
}
