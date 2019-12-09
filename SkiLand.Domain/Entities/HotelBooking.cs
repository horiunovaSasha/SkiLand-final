using System;
using System.Collections.Generic;

namespace SkiLand.Domain.Entities
{
    public class HotelBooking : IEntity
    {
        public long Id { get; set; }
        public HotelRoom HotelRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public Guid UserId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime BookDate { get; set; }
        public List<HotelBookingPayment> Payments { get; set; }
    }
}
