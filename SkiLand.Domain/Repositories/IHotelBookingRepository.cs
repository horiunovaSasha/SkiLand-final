using SkiLand.Domain.Entities;
using SkiLand.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SkiLand.Domain.Repositories
{
    public interface IHotelBookingRepository : IRepository<HotelBooking>
    {
        Task<HotelBooking> CreateBookingAsync(HotelReservationRequest reservation);        
        Task<bool> IsAvailableHotelRoomAsync(long roomId, DateTime startDate, DateTime endDate);
    }
}
