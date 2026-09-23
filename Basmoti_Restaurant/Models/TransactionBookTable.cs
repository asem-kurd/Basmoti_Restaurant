using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class TransactionBookTable : BaseEntityTransaction
{
    [Key]
    public int TransactionBookTableId { get; set; }

    public string TransactionBookTableFullName { get; set; } = null!;

    public string TransactionBookTableEmail { get; set; } = null!;

    public string TransactionBookTableMobileNumber { get; set; } = null!;

    public DateTime TransactionBookTableDate { get; set; }
}
