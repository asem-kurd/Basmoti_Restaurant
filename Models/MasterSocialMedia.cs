using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;


//for footer


public partial class MasterSocialMedia : BaseEntity
{
    [Key]
    public int MasterSocialMediaId { get; set; }

    public string MasterSocialMediaImageUrl { get; set; } = null!;

    public string MasterSocialMediaUrl { get; set; } = null!;
}
