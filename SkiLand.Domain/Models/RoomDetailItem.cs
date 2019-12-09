using SkiLand.Domain.Entities;
using System.Collections.Generic;

namespace SkiLand.Domain.Models
{
    public class RoomDetailItem
    {
        public long Id { get; set; }
        public RoomType RoomType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool IsAvailable { get; set; }
        public List<string> Photos { get; set; }
        public List<string> Amenities { get; set; }
        public List<HotelReservationRequest> Reservations { get; set; }
    }
}
