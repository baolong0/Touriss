using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("From_", TypeName = "datetime")]
        public DateTime? From { get; set; }
        [Column("To_", TypeName = "datetime")]
        public DateTime? To { get; set; }
        [Column("Created_by")]
        public int? CreatedBy { get; set; }
        public int? Type { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Account.Invoices))]
        public virtual Account CreatedByNavigation { get; set; }
        [ForeignKey(nameof(Type))]
        [InverseProperty("Invoices")]
        public virtual Type TypeNavigation { get; set; }
    }
}
