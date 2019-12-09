using Microsoft.EntityFrameworkCore;
using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiLand.DAL.Repositories
{
    public class SeasonRoomPricingRepository : Repository<SeasonRoomPricing>, ISeasonRoomPricingRepository
    {
        public SeasonRoomPricingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Dictionary<DateTime, decimal>> GetRoomPricesAsync(long roomId, DateTime startDate, DateTime endDate)
        {
            var result = new Dictionary<DateTime, decimal>();
            var prices = await dbContext.Set<SeasonRoomPricing>()
                .Where(x => x.StartDate <= startDate && endDate <= x.EndDate && x.HotelRoom.Id == roomId)
                .ToListAsync();

            startDate = startDate.AddDays(1);

            while (startDate.Date <= endDate.Date)
            {
                var price = prices.First(x => x.StartDate <= startDate && startDate <= x.EndDate);
                result.Add(startDate.Date, price.Price);
                startDate = startDate.AddDays(1);
            }

            return result;
        }
    }
}
