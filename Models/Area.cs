using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    public partial class Area
    {
        public Area()
        {
            Addresses = new HashSet<Address>();
            Countries = new HashSet<Country>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }

        [InverseProperty(nameof(Address.AreasNavigation))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(Country.BelongToNavigation))]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
