using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basmoti_Restaurant.Models;

public partial class TransactionBookTable : BaseEntityTransaction
{
    [Key]
    [Display(Name = "Id")]
    public int TransactionBookTableId { get; set; }
    
    [Display(Name = "Full Name")]
    public string TransactionBookTableFullName { get; set; } = null!;

    [Display(Name = "Email")]
    public string TransactionBookTableEmail { get; set; } = null!;

    [Display(Name = "Mobile Number")]
    public string TransactionBookTableMobileNumber { get; set; } = null!;
        
    [Display(Name = "Date")]
    public DateTime TransactionBookTableDate { get; set; }
}
