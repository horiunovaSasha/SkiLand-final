namespace SkiLand.Domain.Entities
{
    public class HotelRoomPhoto : IEntity
    {
        public long Id { get; set; }
        public HotelRoom Room { get; set; }
        public Photo Photo { get; set; }
    }
}
