using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class MasterSlider : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterSliderId { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title")]
    public string MasterSliderTitle { get; set; } = null!;

    [Required(ErrorMessage = "Breef is Required")]
    [Display(Name = "Breef")]
    public string MasterSliderBreef { get; set; } = null!;

    [Required(ErrorMessage = "Description is Required")]
    [Display(Name = "Description")]
    public string MasterSliderDesc { get; set; } = null!;
    
    [Display(Name = "Image")]
    public string? MasterSliderImageUrl { get; set; }
}
