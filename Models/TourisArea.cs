using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Touris_area")]
    public partial class TourisArea
    {
        public TourisArea()
        {
            Photos = new HashSet<Photo>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Descrtiption { get; set; }
        [Column("Address_ID")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("TourisAreas")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Photo.IdRef2))]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
