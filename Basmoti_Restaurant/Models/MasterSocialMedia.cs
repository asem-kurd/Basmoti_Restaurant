using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;


//for footer


public partial class MasterSocialMedia : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterSocialMediaId { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is Required")]
    public string MasterSocialMediaName { get; set; } = null!;

    [Display(Name = "Image")]
    public string? MasterSocialMediaImageUrl { get; set; }

    [Required(ErrorMessage = "URL is Required")]
    [Display(Name = "URL")]
    public string MasterSocialMediaUrl { get; set; } = null!;
}
