using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Wallet")]
    public partial class Wallet
    {
        public Wallet()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(Account.Wallet))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
