using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class TransactionContactUs : BaseEntityTransaction
{

    // form for contact
    [Key]
    [Display(Name = "Id")]
    public int TransactionContactUsId { get; set; }

    [Display(Name = "Full Name")]
    public string TransactionContactUsFullName { get; set; } = null!;

    [Display(Name = "Email")]
    public string TransactionContactUsEmail { get; set; } = null!;

    [Display(Name = "Mobile Number")]
    public string TransactionContactUsSubject { get; set; } = null!;

    [Display(Name = "Message")]
    public string TransactionContactUsMessage { get; set; } = null!;
}
