using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkiLand.Domain.Models;
using SkiLand.Domain.Repositories;

namespace SkiLand.Domain.Services
{
    public class HotelReservationService : IHotelReservationService
    {
        private readonly IHotelRoomRepository _roomRepository;
        private readonly IHotelBookingRepository _bookingRepository;
        private readonly IHotelBookingPaymentRepository _hotelBookingPaymentRepository;
        private readonly ISeasonRoomPricingRepository _seasonRoomPricingRepository;
        public HotelReservationService(
            IHotelRoomRepository roomRepository, 
            IHotelBookingRepository bookingRepository, 
            ISeasonRoomPricingRepository seasonRoomPricingRepository,
            IHotelBookingPaymentRepository hotelBookingPaymentRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _seasonRoomPricingRepository = seasonRoomPricingRepository;
            _hotelBookingPaymentRepository = hotelBookingPaymentRepository;
        }

        public async Task<HotelReservationResponse> CreateReservationAsync(HotelReservationRequest reservation)
        {
            var validationMsgs = await ValidateReservation(reservation);
            var response = new HotelReservationResponse()
            {
                IsSuccessful = !validationMsgs.Any(),
                Messages = validationMsgs
            };

            if (!validationMsgs.Any())
            {
                var booking = await _bookingRepository.CreateBookingAsync(reservation);
                await _bookingRepository.SaveChanges();

                reservation.Id = booking.Id;
                reservation.BookingDate = booking.BookDate;

                var prices = await _seasonRoomPricingRepository.GetRoomPricesAsync(reservation.RoomId, reservation.StartDate.Date, reservation.EndDate.Date);
                await _hotelBookingPaymentRepository.AddBookingPaymentInfoAsync(booking.Id, prices);
                await _hotelBookingPaymentRepository.SaveChanges();

                reservation.Price = prices.Sum(x => x.Value);
            }

            return response;            
        }

        private async Task<List<string>> ValidateReservation(HotelReservationRequest reservation)
        {
            var errors = new List<string>();
            var currentDate = DateTime.Now.Date;

            if (reservation.StartDate.Date < currentDate || reservation.EndDate.Date < currentDate || reservation.EndDate.Date < reservation.StartDate.Date)
            {
                errors.Add("Дати резервації вибрано не коректно!");
            }

            if (!errors.Any())
            {
                var room = await _roomRepository.FindById(reservation.RoomId);

                if (reservation.Adults > room.Adults || reservation.Children > room.Children)
                {
                    errors.Add("Кількість людей перевищує вмістимість номеру!");
                }
            }

            if (!errors.Any())
            {
                var isAvailable = await _bookingRepository.IsAvailableHotelRoomAsync(reservation.RoomId, reservation.StartDate.Date, reservation.EndDate.Date);
                if (!isAvailable)
                {
                    errors.Add("Нажаль, не має вільного номеру за вказаними датами");
                }
            }

            return errors;
        }
    }
}
