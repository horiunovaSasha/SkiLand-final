using SkiLand.Domain.Models;
using System.Threading.Tasks;

namespace SkiLand.Domain.Services
{
    public interface IHotelReservationService
    {
        Task<HotelReservationResponse> CreateReservationAsync(HotelReservationRequest reservation);
    }
}
