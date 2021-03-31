using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("Belong_to")]
        public int? BelongTo { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(Area.Countries))]
        public virtual Area BelongToNavigation { get; set; }
        [InverseProperty(nameof(Address.CountryNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(City.BelongToNavigation))]
        public virtual ICollection<City> Cities { get; set; }
    }
}
