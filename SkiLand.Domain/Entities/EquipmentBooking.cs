using System;
namespace SkiLand.Domain.Entities
{
    public class EquipmentBooking : IEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set;  }
    }
}
