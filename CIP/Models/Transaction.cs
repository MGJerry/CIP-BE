using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CIP.Models;

public partial class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Type { get; set; }

    public string? Method { get; set; }

    public double? Total { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;

    public virtual TransactionDetail? TransactionDetail { get; set; }
}
