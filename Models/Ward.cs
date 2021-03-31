using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Ward")]
    public partial class Ward
    {
        public Ward()
        {
            Addresses = new HashSet<Address>();
            ApartmentNumbers = new HashSet<ApartmentNumber>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Belong_to")]
        public int? BelongTo { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(District.Wards))]
        public virtual District BelongToNavigation { get; set; }
        [InverseProperty(nameof(Address.WardNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(ApartmentNumber.BelongToNavigation))]
        public virtual ICollection<ApartmentNumber> ApartmentNumbers { get; set; }
    }
}
