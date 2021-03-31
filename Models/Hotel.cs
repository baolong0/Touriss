using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Photos = new HashSet<Photo>();
            Types = new HashSet<Type>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [Column("Address_ID")]
        public int? AddressId { get; set; }
        [Column("Total_room")]
        public int? TotalRoom { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Hotels")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Photo.IdRef1))]
        public virtual ICollection<Photo> Photos { get; set; }
        [InverseProperty(nameof(Type.IdHotelNavigation))]
        public virtual ICollection<Type> Types { get; set; }
    }
}
