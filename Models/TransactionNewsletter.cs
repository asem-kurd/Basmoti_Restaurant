using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class TransactionNewsletter : BaseEntityTransaction
{


    // for footer
    [Key]
    public int TransactionNewsletterId { get; set; }

    public string TransactionNewsletterEmail { get; set; } = null!;
}
