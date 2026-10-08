using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class TransactionNewsletter : BaseEntityTransaction
{


    // for footer
    [Key]
    [Display(Name = "Id")]
    public int TransactionNewsletterId { get; set; }
    
    [Display(Name = "Email")]
    public string TransactionNewsletterEmail { get; set; } = null!;
}
