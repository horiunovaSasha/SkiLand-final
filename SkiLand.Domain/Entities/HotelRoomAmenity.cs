using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class HotelRoomAmenity : IEntity
    {
        public long Id { get; set; }
        //public int HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
        //public int RoomAmenityId { get; set; }
        public RoomAmenity RoomAmenity { get; set; }
    }
}
