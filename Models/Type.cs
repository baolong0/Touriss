using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public long? Price { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [Column("ID_hotel")]
        public int? IdHotel { get; set; }

        [ForeignKey(nameof(IdHotel))]
        [InverseProperty(nameof(Hotel.Types))]
        public virtual Hotel IdHotelNavigation { get; set; }
        [InverseProperty(nameof(Invoice.TypeNavigation))]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
