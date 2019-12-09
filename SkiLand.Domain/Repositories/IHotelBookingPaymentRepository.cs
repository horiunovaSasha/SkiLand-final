using SkiLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkiLand.Domain.Repositories
{
    public interface IHotelBookingPaymentRepository : IRepository<HotelBookingPayment>
    {
        Task AddBookingPaymentInfoAsync(long bookingId, Dictionary<DateTime, decimal> payments);
    }
}
