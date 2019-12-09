using System;
namespace SkiLand.Domain.Entities
{
    public class Restaurant : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public float Raiting { get; set; }
        public DateTime TimeOpen { get; set; }
        public DateTime TimeClose {get; set;}
        //public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public string ContactInformation { get; set; }
    }
}
