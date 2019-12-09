using System;

namespace SkiLand.Domain.Entities
{
    public class RestaurantBooking : IEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int PeopleCount { get; set; }
        //public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string Comment { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
