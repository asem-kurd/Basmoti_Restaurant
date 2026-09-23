using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;



// for menu page (filter)


// one side
public partial class MasterCategoryMenu : BaseEntity
{
    [Key]
    public int MasterCategoryMenuId { get; set; }

    public string MasterCategoryMenuName { get; set; } = null!;

    public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
}
