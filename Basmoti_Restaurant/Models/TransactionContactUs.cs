using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class TransactionContactUs : BaseEntityTransaction
{

    // form for contact
    [Key]
    public int TransactionContactUsId { get; set; }

    public string TransactionContactUsFullName { get; set; } = null!;

    public string TransactionContactUsEmail { get; set; } = null!;

    public string TransactionContactUsSubject { get; set; } = null!;

    public string TransactionContactUsMessage { get; set; } = null!;
}
