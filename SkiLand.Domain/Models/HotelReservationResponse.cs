using System.Collections.Generic;

namespace SkiLand.Domain.Models
{
    public class HotelReservationResponse
    {
        public bool IsSuccessful { get; set; }
        public List<string> Messages { get; set; }
    }
}
