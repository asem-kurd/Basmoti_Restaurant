using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class MasterOffer : BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int MasterOfferId { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title")]
    public string MasterOfferTitle { get; set; } = null!;

    [Required(ErrorMessage = "Title is Breef")]
    [Display(Name = "Breef")]
    public string MasterOfferBreef { get; set; } = null!;

    [Required(ErrorMessage = "Title is Description")]
    [Display(Name = "Description")]
    public string MasterOfferDesc { get; set; } = null!;


    [Display(Name = "Image")]
    public string? MasterOfferImageUrl { get; set; }


    
}
