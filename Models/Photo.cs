using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Photo")]
    public partial class Photo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(2000)]
        public string Url { get; set; }
        [Column("ID_ref")]
        public int? IdRef { get; set; }

        [ForeignKey(nameof(IdRef))]
        [InverseProperty(nameof(Hotel.Photos))]
        public virtual Hotel IdRef1 { get; set; }
        [ForeignKey(nameof(IdRef))]
        [InverseProperty(nameof(TourisArea.Photos))]
        public virtual TourisArea IdRef2 { get; set; }
        [ForeignKey(nameof(IdRef))]
        [InverseProperty(nameof(City.Photos))]
        public virtual City IdRefNavigation { get; set; }
    }
}
