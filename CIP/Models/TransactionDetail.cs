using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CIP.Models;

public partial class TransactionDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? TransactionId { get; set; }

    public int? ProductId { get; set; }

    public double? Amount { get; set; }

    public double? Subtotal { get; set; }

    public virtual Transaction Id1 { get; set; } = null!;

    public virtual Product IdNavigation { get; set; } = null!;
}
