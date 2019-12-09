using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class RelaxServiceBooking : IEntity
    {
        public long Id { get; set; }
        //public int RelaxServiceId { get; set; }
        public RelaxServise RelaxServise { get; set; }
        public int UserId { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
