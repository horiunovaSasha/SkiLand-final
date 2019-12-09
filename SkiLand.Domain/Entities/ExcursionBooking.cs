using System;
namespace SkiLand.Domain.Entities
{
    public class ExcurisionBooking : IEntity
    {
        public long Id { get; set; }
        //public int ExcurisionServiceId { get; set; }
        public ExcursionService ExcursionService { get; set; }
        public int UserId { get; set; }        
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set;  }
    }
}
