using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Apartment_number")]
    public partial class ApartmentNumber
    {
        public ApartmentNumber()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Belong_to")]
        public int? BelongTo { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(Ward.ApartmentNumbers))]
        public virtual Ward BelongToNavigation { get; set; }
        [InverseProperty(nameof(Address.ApartmentNumberNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
