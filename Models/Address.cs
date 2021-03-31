using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Touriss.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Hotels = new HashSet<Hotel>();
            TourisAreas = new HashSet<TourisArea>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int? Areas { get; set; }
        public int? Country { get; set; }
        public int? City { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        [Column("Apartment_number")]
        public int? ApartmentNumber { get; set; }

        [ForeignKey(nameof(ApartmentNumber))]
        [InverseProperty("Addresses")]
        public virtual ApartmentNumber ApartmentNumberNavigation { get; set; }
        [ForeignKey(nameof(Areas))]
        [InverseProperty(nameof(Area.Addresses))]
        public virtual Area AreasNavigation { get; set; }
        [ForeignKey(nameof(City))]
        [InverseProperty("Addresses")]
        public virtual City CityNavigation { get; set; }
        [ForeignKey(nameof(Country))]
        [InverseProperty("Addresses")]
        public virtual Country CountryNavigation { get; set; }
        [ForeignKey(nameof(District))]
        [InverseProperty("Addresses")]
        public virtual District DistrictNavigation { get; set; }
        [ForeignKey(nameof(Ward))]
        [InverseProperty("Addresses")]
        public virtual Ward WardNavigation { get; set; }
        [InverseProperty(nameof(Hotel.Address))]
        public virtual ICollection<Hotel> Hotels { get; set; }
        [InverseProperty(nameof(TourisArea.Address))]
        public virtual ICollection<TourisArea> TourisAreas { get; set; }
    }
}
