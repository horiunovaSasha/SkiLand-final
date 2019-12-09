using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class HotelRoom : IEntity
    {
        public long Id { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomsCount { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }        
        public List<HotelRoomPhoto> Photos { get; set; }
        public List<SeasonRoomPricing> Pricings { get; set; }
        public List<HotelBooking> Bookings { get; set; }
        public List<HotelRoomAmenity> Amenities { get; set; }
    }
}
