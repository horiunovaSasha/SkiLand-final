using System;

namespace SkiLand.Domain.Entities
{
    public class HotelBookingPayment : IEntity
    {
        public long Id { get; set; }
        public HotelBooking Booking { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Disscount { get; set; }
        public bool IsPercentDisscount { get; set; }
    }
}
