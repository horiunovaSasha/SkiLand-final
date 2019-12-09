using SkiLand.Domain.Models;

namespace SkiLand.Domain.Repositories
{
    public interface IBookingRepository
    {
        void CreateBooking(HotelReservationRequest reservation);
        void AddBookingPaymentInfo();
    }
}
