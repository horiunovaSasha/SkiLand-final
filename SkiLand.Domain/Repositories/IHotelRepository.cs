using SkiLand.Domain.Entities;
using SkiLand.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkiLand.Domain.Repositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<List<HotelListItem>> GetListAsync(HotelReservationRequest request);
        Task<HotelDetailItem> GetDetails(HotelReservationRequest request);
    }
}
