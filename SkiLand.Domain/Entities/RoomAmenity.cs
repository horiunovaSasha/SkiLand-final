using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class RoomAmenity : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
