using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Repositories;

namespace SkiLand.DAL.Repositories
{
    public class HotelRoomRepository: Repository<HotelRoom>, IHotelRoomRepository
    {
        public HotelRoomRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
