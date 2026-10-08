using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;



// about page (Our Services)
public partial class MasterService : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterServicesId { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title")]
    public string MasterServicesTitle { get; set; } = null!;

    [Required(ErrorMessage = "Description is Required")]
    [Display(Name = "Description")]
    public string MasterServicesDesc { get; set; } = null!;

    [Display(Name = "Image")]
    public string? MasterServicesImage { get; set; }
}
