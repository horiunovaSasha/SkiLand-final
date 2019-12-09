using SkiLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkiLand.Domain.Repositories
{
    public interface ISeasonRoomPricingRepository : IRepository<SeasonRoomPricing>
    {
        Task<Dictionary<DateTime, decimal>> GetRoomPricesAsync(long roomId, DateTime startDate, DateTime endDate);
    }
}
