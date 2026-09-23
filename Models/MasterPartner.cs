using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterPartner : BaseEntity
{
    [Key]
    public int MasterPartnerId { get; set; }

    public string MasterPartnerName { get; set; } = null!;

    public string MasterPartnerLogoImageUrl { get; set; } = null!;

    public string MasterPartnerWebsiteUrl { get; set; } = null!;
}
