using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkiLand.Domain.Models;
using SkiLand.Domain.Repositories;
using SkiLand.Domain.Services;
using SkiLand.Web.Models;
using System;
using System.Threading.Tasks;

namespace SkiLand.Web.Controllers
{
    [Route("Hotels")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;
        private readonly IHotelReservationService _reservationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public HotelController(IHotelRepository repository, IHotelReservationService reservationService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _reservationService = reservationService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // GET: Hotel
        public async Task <ActionResult> Index(HotelReservationRequest request)
        {
            var hotels = await _repository.GetListAsync(request);
            ViewBag.Request = request;

            return View(hotels);
        }

        // GET: Hotel Details
        [Route("{HotelId}")]
        [Route("{HotelId}/roomtype/{RoomTypeId}")]
        public async Task<ActionResult> Details(HotelReservationRequest request)
        {
            var resJson = TempData["ReservationRequest"] as string;
            if (!string.IsNullOrEmpty(resJson))
            {
                ViewBag.Request = JsonConvert.DeserializeObject<HotelReservationRequest>(resJson);
            }

            if (_signInManager.IsSignedIn(User))
            {
                request.UserId = Guid.Parse((await _userManager.GetUserAsync(User)).Id);
            }

            var hotelInfo = await _repository.GetDetails(request);
            return View(hotelInfo);
        }

        [HttpPost]
        [Route("{hotel}")]
        [Route("{hotel}/roomtype/{roomType}")]
        public async Task<ActionResult> Reservation(HotelDetailItem hotelInfo)
        {
            var reservation = hotelInfo.ReservationRequest;

            if (_signInManager.IsSignedIn(User))
            {
                reservation.UserId = Guid.Parse((await _userManager.GetUserAsync(User)).Id);
                var response = await _reservationService.CreateReservationAsync(reservation);
                ViewBag.Response = response;

                if (response.IsSuccessful)
                {
                    TempData.Add("ReservationRequest", JsonConvert.SerializeObject(reservation));
                    return Redirect($"/hotels/{reservation.HotelId}/roomtype/{reservation.RoomTypeId}");
                }
                else
                {
                    hotelInfo = await _repository.GetDetails(reservation);
                    hotelInfo.ReservationRequest = reservation;

                    return View("Details", hotelInfo);
                }
            } else
            {
                return Redirect($"/account/login?returnUrl=/hotels/{reservation.HotelId}/roomtype/{reservation.RoomTypeId}");
            }
        }
    }
}