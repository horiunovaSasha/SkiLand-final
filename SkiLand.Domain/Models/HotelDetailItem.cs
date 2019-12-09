using SkiLand.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SkiLand.Domain.Models
{
    public class HotelDetailItem
    {
        public HotelDetailItem()
        {
            ReservationRequest = new HotelReservationRequest()
            {
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(1).Date
            };
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public float Raiting { get; set; }
        public byte Stars { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PhotoPath { get; set; }
        public RoomDetailItem Room { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public HotelReservationRequest ReservationRequest { get; set; }
        public HotelReservationResponse ReservationResponse { get; set; }        
    }
}
