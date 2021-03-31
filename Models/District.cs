using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("District")]
    public partial class District
    {
        public District()
        {
            Addresses = new HashSet<Address>();
            Wards = new HashSet<Ward>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Belong_to")]
        public int? BelongTo { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(City.Districts))]
        public virtual City BelongToNavigation { get; set; }
        [InverseProperty(nameof(Address.DistrictNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(Ward.BelongToNavigation))]
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
