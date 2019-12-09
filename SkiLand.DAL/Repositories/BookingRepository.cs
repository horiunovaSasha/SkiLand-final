using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Models;
using SkiLand.Domain.Repositories;
using System;

namespace SkiLand.DAL.Repositories
{
    public class BookingRepository : Repository<HotelBooking>, IBookingRepository
    {
        public BookingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void AddBookingPaymentInfo()
        {
            throw new NotImplementedException();
        }

        public void CreateBooking(HotelReservationRequest reservation)
        {
            throw new NotImplementedException();
        }
    }
}
