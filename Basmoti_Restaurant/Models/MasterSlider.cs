using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterSlider : BaseEntity
{
    [Key]
    public int MasterSliderId { get; set; }

    public string MasterSliderTitle { get; set; } = null!;

    public string MasterSliderBreef { get; set; } = null!;

    public string MasterSliderDesc { get; set; } = null!;

    public string MasterSliderImageUrl { get; set; } = null!;
}
