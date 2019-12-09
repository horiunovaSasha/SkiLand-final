using Microsoft.EntityFrameworkCore;
using SkiLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.DAL.DdContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentBooking> EquipmentBookings { get; set; }
        public DbSet<EquipmentRental> EquipmentRentals { get; set; }
        public DbSet<EquipmentState> EquipmentStates { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<ExcursionAgency> ExcursionAgencies { get; set; }
        public DbSet<ExcursionAgencyService> ExcursionAgencyServices { get; set; }
        public DbSet<ExcurisionBooking> ExcurisionBookings { get; set; }
        public DbSet<ExcursionService> ExcursionServices { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomAmenity> HotelRoomAmenities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RelaxComplex> RelaxComplexes { get; set; }
        public DbSet<RelaxServiceBooking> RelaxServiceBookings { get; set; }
        public DbSet<RelaxServiceRelaxComplex> RelaxServiceRelaxComplexes { get; set; }
        public DbSet<RelaxServise> RelaxServises { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantBooking> RestaurantBookings { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<SeasonRoomPricing> SeasonRoomPricings { get; set; }
        public DbSet<HotelRoomPhoto> HotelRoomPhotos { get; set; }
        public DbSet<HotelBookingPayment> HotelBookingPayments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddPrimaryKey<Equipment>(modelBuilder);
            AddPrimaryKey<EquipmentBooking>(modelBuilder);
            AddPrimaryKey<EquipmentRental>(modelBuilder);
            AddPrimaryKey<EquipmentState>(modelBuilder);
            AddPrimaryKey<EquipmentType>(modelBuilder);
            AddPrimaryKey<ExcursionAgency>(modelBuilder);
            AddPrimaryKey<ExcursionAgencyService>(modelBuilder);
            AddPrimaryKey<ExcurisionBooking>(modelBuilder);
            AddPrimaryKey<ExcursionService>(modelBuilder);
            AddPrimaryKey<Hotel>(modelBuilder);
            AddPrimaryKey<HotelBooking>(modelBuilder);
            AddPrimaryKey<HotelRoom>(modelBuilder);
            AddPrimaryKey<HotelRoomAmenity>(modelBuilder);
            AddPrimaryKey<Photo>(modelBuilder);
            AddPrimaryKey<RelaxComplex>(modelBuilder);
            AddPrimaryKey<RelaxServiceBooking>(modelBuilder);
            AddPrimaryKey<RelaxServiceRelaxComplex>(modelBuilder);
            AddPrimaryKey<RelaxServise>(modelBuilder);
            AddPrimaryKey<Restaurant>(modelBuilder);
            AddPrimaryKey<RestaurantBooking>(modelBuilder);
            AddPrimaryKey<RoomAmenity>(modelBuilder);
            AddPrimaryKey<RoomType>(modelBuilder);
            AddPrimaryKey<SeasonRoomPricing>(modelBuilder);
            AddPrimaryKey<HotelBookingPayment>(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Hotel);

            modelBuilder.Entity<HotelRoom>()
                .HasMany(x => x.Pricings)
                .WithOne(x => x.HotelRoom);

            modelBuilder.Entity<HotelRoom>()
                .HasMany(x => x.Bookings)
                .WithOne(x => x.HotelRoom);
        }

        private void AddPrimaryKey<T>(ModelBuilder modelBuilder) where T: class, IEntity
        {
            modelBuilder.Entity<T>().HasKey(x => x.Id);
            modelBuilder.Entity<T>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
