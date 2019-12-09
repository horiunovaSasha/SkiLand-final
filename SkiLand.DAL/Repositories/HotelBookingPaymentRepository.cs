using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkiLand.DAL.Repositories
{
    public class HotelBookingPaymentRepository : Repository<HotelBookingPayment>, IHotelBookingPaymentRepository
    {
        public HotelBookingPaymentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddBookingPaymentInfoAsync(long bookingId, Dictionary<DateTime, decimal> payments)
        {
            foreach(var payment in payments)
            {
                await CreateAsync(new HotelBookingPayment()
                {
                    Booking = new HotelBooking() { Id = bookingId },
                    Date = payment.Key,
                    Price = payment.Value
                });
            }

            dbContext.SaveChanges();
        }
    }
}
