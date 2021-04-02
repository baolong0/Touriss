using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Touriss.Models
{
    public partial class TourissContext : DbContext
    {
        public TourissContext()
        {
        }

        public TourissContext(DbContextOptions<TourissContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ApartmentNumber> ApartmentNumbers { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<TourisArea> TourisAreas { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=Touriss.mssql.somee.com;packet size=4096;user id=adminbll_SQLLogin_1;pwd=iz4b1mfdfn;data source=Touriss.mssql.somee.com;persist security info=False;initial catalog=Touriss");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.InviteCode).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK__Account__Wallet___46E78A0C");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ApartmentNumberNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ApartmentNumber)
                    .HasConstraintName("FK__Address__Apartme__398D8EEE");

                entity.HasOne(d => d.AreasNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Areas)
                    .HasConstraintName("FK__Address__Areas__34C8D9D1");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK__Address__City__36B12243");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__Address__Country__35BCFE0A");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.District)
                    .HasConstraintName("FK__Address__Distric__37A5467C");

                entity.HasOne(d => d.WardNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Ward)
                    .HasConstraintName("FK__Address__Ward__38996AB5");
            });

            modelBuilder.Entity<ApartmentNumber>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.ApartmentNumbers)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK__Apartment__Belon__31EC6D26");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK__City__Belong_to__29572725");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK__Country__Belong___267ABA7A");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK__District__Belong__2C3393D0");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Hotel__Address_I__3C69FB99");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Invoice__Created__4E88ABD4");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__Invoice__Type__4F7CD00D");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.IdRefNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdRef)
                    .HasConstraintName("FK__Photo__ID_ref__4BAC3F29");

                entity.HasOne(d => d.IdRef1)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdRef)
                    .HasConstraintName("FK__Photo__ID_ref__49C3F6B7");

                entity.HasOne(d => d.IdRef2)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdRef)
                    .HasConstraintName("FK__Photo__ID_ref__4AB81AF0");
            });

            modelBuilder.Entity<TourisArea>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TourisAreas)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Touris_ar__Addre__3F466844");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.IdHotel)
                    .HasConstraintName("FK__Type__ID_hotel__4222D4EF");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BelongToNavigation)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.BelongTo)
                    .HasConstraintName("FK__Ward__Belong_to__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
