using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Districts = new HashSet<District>();
            Photos = new HashSet<Photo>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Belong_to")]
        public int? BelongTo { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(Country.Cities))]
        public virtual Country BelongToNavigation { get; set; }
        [InverseProperty(nameof(Address.CityNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(District.BelongToNavigation))]
        public virtual ICollection<District> Districts { get; set; }
        [InverseProperty(nameof(Photo.IdRefNavigation))]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
