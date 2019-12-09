using System;

namespace SkiLand.Domain.Models
{
    public class HotelReservationRequest
    {
        public HotelReservationRequest()
        {
            StartDate = DateTime.Now.Date;
            EndDate = StartDate.AddDays(1);
            Adults = 1;
            Page = 1;
            PageCount = 1;
            SortOrder = SortOrderEnum.Asc;
            Sort = HotelSortEnum.Price;
        }

        public long Id { get; set; }
        public long HotelId { get; set; }
        public long RoomId { get; set; }
        public int RoomTypeId { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BookingDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }

        public int Page { get; set; }
        public int PageCount { get; set; }
        public SortOrderEnum SortOrder { get; set; }
        public HotelSortEnum Sort { get; set; }

        public bool IsValid
        {
            get { return StartDate >= DateTime.Now.Date && StartDate.Date < EndDate.Date && Adults > 0; }
        }
    }
}
