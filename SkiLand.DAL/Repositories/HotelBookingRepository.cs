using Microsoft.EntityFrameworkCore;
using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Models;
using SkiLand.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkiLand.DAL.Repositories
{
    public class HotelBookingRepository : Repository<HotelBooking>, IHotelBookingRepository
    {
        public HotelBookingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<HotelBooking> CreateBookingAsync(HotelReservationRequest reservation)
        {
           return await base.CreateAsync(new HotelBooking() {
               HotelRoom = new HotelRoom() { Id = reservation.RoomId },
                Adults = reservation.Adults,
                Children = reservation.Children,
                EndDate = reservation.EndDate.Date,
                StartDate = reservation.StartDate.Date,
                UserId = reservation.UserId,
                BookDate = DateTime.Now,
                IsConfirmed = true
            });
        }

        public async Task<bool> IsAvailableHotelRoomAsync(long roomId, DateTime startDate, DateTime endDate)
        {
            return await dbContext.Set<HotelRoom>()
                .AnyAsync(x => x.Id == roomId && x.RoomsCount > x.Bookings.Count(b =>
                        ((b.StartDate < endDate && endDate <= b.EndDate) ||
                        (startDate < b.EndDate && startDate >= b.StartDate) ||
                        (startDate <= b.StartDate && b.EndDate <= endDate))));
        }
    }
}
