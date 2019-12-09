using SkiLand.Domain.Entities;

namespace SkiLand.Domain.Models
{
    public class HotelListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Raiting { get; set; }
        public byte Stars { get; set; }
        public string Location { get; set; }
        public string PhotoPath { get; set; }
        public decimal PriceFrom { get; set; }
        public bool IsAvailable {
            get
            {
                return PriceFrom > 0;
            }
        }
    }
}
