using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;


// for menu page (filter)
public partial class MasterItemMenu:BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterItemMenuId { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title")]
    public string MasterItemMenuTitle { get; set; } = null!;

    [Required(ErrorMessage = "Breef is Required")]
    [Display(Name = "Breef")]
    public string MasterItemMenuBreef { get; set; } = null!;

    [Required(ErrorMessage = "Description is Required")]
    [Display(Name = "Description")]
    public string MasterItemMenuDesc { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    [Required(ErrorMessage = "Price is Required")]
    [Display(Name = "Price")]
    public double MasterItemMenuPrice { get; set; }


    [Display(Name = "Image")]
    public string? MasterItemMenuImageUrl { get; set; }

    [Display(Name = "Date")]
    public DateTime MasterItemMenuDate { get; set; }


    // many side


    [Required(ErrorMessage = "Category Menu is Required")]
    [Display(Name = "Category Menu")]
    public int MasterCategoryMenuId { get; set; }

    public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
}
