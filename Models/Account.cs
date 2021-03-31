using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Date_of_birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Column("Phone_number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public bool? Gender { get; set; }
        [Column("Invite_Code")]
        [StringLength(20)]
        public string InviteCode { get; set; }
        [Column("Invited_by")]
        public int? InvitedBy { get; set; }
        [Column("Wallet_ID")]
        public int? WalletId { get; set; }

        [ForeignKey(nameof(WalletId))]
        [InverseProperty("Accounts")]
        public virtual Wallet Wallet { get; set; }
        [InverseProperty(nameof(Invoice.CreatedByNavigation))]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
