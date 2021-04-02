using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Touriss.Models;
using Type = Touriss.Models.Type;

namespace Touriss.Dtos
{
    public class HotelToReturnDto
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }

        [Column("Address_ID")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Hotels")]
        public virtual string Address { get; set; }

        public virtual string Types { get; set; }

        [InverseProperty(nameof(Photo.IdRef1))]
        public virtual string Photos { get; set; }
   
    }
}
