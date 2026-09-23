using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterOffer : BaseEntity
{
    [Key]
    public int MasterOfferId { get; set; }

    public string MasterOfferTitle { get; set; } = null!;

    public string MasterOfferBreef { get; set; } = null!;

    public string MasterOfferDesc { get; set; } = null!;

    public string MasterOfferImageUrl { get; set; } = null!;
}
