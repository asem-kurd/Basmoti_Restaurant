using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class MasterPartner : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterPartnerId { get; set; }

    [Required(ErrorMessage = "Name is Required")]
    [Display(Name = "Name")]
    public string MasterPartnerName { get; set; } = null!;

    //[Required(ErrorMessage = "Logo Image is Required")]
    [Display(Name = "Logo Image")]
    public string? MasterPartnerLogoImageUrl { get; set; }

    [Required(ErrorMessage = "Website URL is Required")]
    [Display(Name = "Website URL")]
    public string MasterPartnerWebsiteUrl { get; set; } = null!;
}
