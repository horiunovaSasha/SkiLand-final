using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class SeasonRoomPricing : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public HotelRoom HotelRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

    }
}
