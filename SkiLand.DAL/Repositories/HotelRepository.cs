using Microsoft.EntityFrameworkCore;
using SkiLand.DAL.DdContext;
using SkiLand.Domain.Entities;
using SkiLand.Domain.Models;
using SkiLand.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkiLand.DAL.Repositories
{
    public class HotelRepository: Repository<Hotel>, IHotelRepository
    {
        private const int PAGE_ITEMS = 6;
        public HotelRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<HotelListItem>> GetListAsync(HotelReservationRequest request)
        {
            if (!request.IsValid)
            {
                return new List<HotelListItem>();
            }

            var availableRooms = (
                from rooms in dbContext.Set<HotelRoom>()
                from hotelBookins in dbContext.Set<HotelBooking>()
                    .Where(b => b.HotelRoom.Id == rooms.Id &&
                        ((b.StartDate < request.EndDate && request.EndDate <= b.EndDate) ||
                        (request.StartDate < b.EndDate && request.StartDate >= b.StartDate) ||
                        (request.StartDate <= b.StartDate && b.EndDate <= request.EndDate)))
                        .DefaultIfEmpty()
                where
                   rooms.Adults >= request.Adults && rooms.Children >= request.Children
                group hotelBookins.Id by new { rooms.Id, rooms.RoomsCount } into grouped
                where grouped.Count() < grouped.Key.RoomsCount 
                select grouped.Key.Id)
            .ToList();

            var roomPrices = dbContext.Set<SeasonRoomPricing>()
                .Where(p => availableRooms.Contains(p.HotelRoom.Id) &&
                    ((p.StartDate < request.EndDate && request.EndDate <= p.EndDate) ||
                    (request.StartDate < p.EndDate && request.StartDate >= p.StartDate) ||
                    (request.StartDate <= p.StartDate && p.EndDate <= request.EndDate)))
                .Select(p => new { p.Id, HotelId = p.HotelRoom.Hotel.Id, RoomId = p.HotelRoom.Id, p.Price })
                .GroupBy(p => p.HotelId)
                .Select(p => p.First(x => x.Price == p.Min(m => m.Price)))
                .ToList();

            var priceIds = roomPrices.Select(x => x.Id);
            var roomIds = roomPrices.Select(x => x.RoomId);

            var query =
                from hotels in dbContext.Set<Hotel>()
                from rooms in dbContext.Set<HotelRoom>()
                    .Where(r => r.Hotel.Id == hotels.Id && roomIds.Contains(r.Id))
                    .DefaultIfEmpty()
                from prices in dbContext.Set<SeasonRoomPricing>()
                    .Where(p => priceIds.Contains(p.Id) && p.HotelRoom.Id == rooms.Id)
                    .DefaultIfEmpty()
                select new HotelListItem()
                {
                    Id = hotels.Id,
                    Name = hotels.Name,
                    Description = hotels.Description,
                    PhotoPath = hotels.Photo.Path,
                    Stars = hotels.Stars,
                    Raiting = hotels.Raiting,
                    PriceFrom = prices == null ? 0 : prices.Price
                };

            if (request.SortOrder == SortOrderEnum.Asc) { 
                switch(request.Sort)
                {
                    case HotelSortEnum.Price:
                        query = query.OrderBy(x => x.PriceFrom);
                        query = query.OrderBy(x => x.PriceFrom == 0 ? 1 : 0);
                        break;
                    case HotelSortEnum.Raiting:
                        query = query.OrderBy(x => x.Raiting);
                        break;
                    case HotelSortEnum.Stars:
                        query = query.OrderBy(x => x.Stars);
                        break;
                    case HotelSortEnum.Name:
                        query = query.OrderBy(x => x.Name);
                        break;
                }
            } else
            {
                switch (request.Sort)
                {
                    case HotelSortEnum.Price:
                        query = query.OrderByDescending(x => x.PriceFrom);
                        query = query.OrderByDescending(x => x.PriceFrom == 0 ? 1 : 0);
                        break;
                    case HotelSortEnum.Raiting:
                        query = query.OrderByDescending(x => x.Raiting);
                        break;
                    case HotelSortEnum.Stars:
                        query = query.OrderByDescending(x => x.Stars);
                        break;
                    case HotelSortEnum.Name:
                        query = query.OrderByDescending(x => x.Name);
                        break;
                }
            }

            request.PageCount = (int)Math.Ceiling((double)dbContext.Set<Hotel>().Count() / PAGE_ITEMS);

            return await query
                .Skip((request.Page - 1) * PAGE_ITEMS)
                .Take(PAGE_ITEMS)
                .ToListAsync();
        }

        public async Task<HotelDetailItem> GetDetails(HotelReservationRequest request)
        {
            var roomId = (
                from rooms in dbContext.Set<HotelRoom>()
                from hotelBookins in dbContext.Set<HotelBooking>()
                    .Where(b => b.HotelRoom.Id == rooms.Id &&
                        ((b.StartDate < request.EndDate && request.EndDate <= b.EndDate) ||
                        (request.StartDate < b.EndDate && request.StartDate >= b.StartDate) ||
                        (request.StartDate <= b.StartDate && b.EndDate <= request.EndDate)))
                        .DefaultIfEmpty()
                from pricing in dbContext.Set<SeasonRoomPricing>()
                    .Where(b => b.HotelRoom.Id == rooms.Id &&
                        ((b.StartDate < request.EndDate && request.EndDate <= b.EndDate) ||
                        (request.StartDate < b.EndDate && request.StartDate >= b.StartDate) ||
                        (request.StartDate <= b.StartDate && b.EndDate <= request.EndDate)))
                        .DefaultIfEmpty()
                where
                   rooms.Hotel.Id == request.HotelId && 
                   rooms.Adults >= request.Adults && 
                   rooms.Children >= request.Children &&
                   (request.RoomTypeId == 0 || rooms.RoomType.Id == request.RoomTypeId)
                group hotelBookins.Id by new { rooms.Id, rooms.RoomsCount } into grouped
                where grouped.Count() < grouped.Key.RoomsCount
                select grouped.Key.Id)
            .FirstOrDefault();

            decimal price = 0;

            if (roomId != 0)
            {
                price = dbContext.Set<SeasonRoomPricing>()
                    .Where(p => p.HotelRoom.Id == roomId &&
                        ((p.StartDate < request.EndDate && request.EndDate <= p.EndDate) ||
                        (request.StartDate < p.EndDate && request.StartDate >= p.StartDate) ||
                        (request.StartDate <= p.StartDate && p.EndDate <= request.EndDate))
                    ).Min(x => x.Price);
            }


            return await dbContext.Set<HotelRoom>()
                .Where(x => 
                    x.Hotel.Id == request.HotelId && 
                    (roomId == 0 || x.Id == roomId) && 
                    (request.RoomTypeId == 0 || x.RoomType.Id == request.RoomTypeId))
                .OrderBy(x => x.RoomType.Id)
                .Select(x => new HotelDetailItem()
                {
                    Id = x.Hotel.Id,
                    Name = x.Hotel.Name,
                    PhotoPath = x.Hotel.Photo.Path,
                    Stars = x.Hotel.Stars,
                    Raiting = x.Hotel.Raiting,
                    Description = x.Hotel.Description,
                    Location = x.Hotel.Location,
                    RoomTypes = x.Hotel.Rooms
                        .Select(r => r.RoomType)
                        .ToList(),
                    Room = new RoomDetailItem()
                    {
                        Id = x.Id,
                        Adults = x.Adults,
                        Children = x.Children,
                        Description = x.Description,
                        RoomType = x.RoomType,
                        IsAvailable = roomId != 0,
                        Price = price,
                        Amenities = x.Amenities
                            .Select(a => a.RoomAmenity)
                            .Select(am => am.Title)
                            .ToList(),
                        Photos = x.Photos
                            .Select(p => p.Photo)
                            .Select(ph => ph.Path)
                            .ToList(),
                        Reservations = x.Bookings
                            .Where(b => b.UserId == request.UserId && b.EndDate > request.StartDate)
                            .OrderBy(b => b.BookDate)
                            .Select(b => new HotelReservationRequest()
                            {
                                Id = b.Id,
                                BookingDate = b.BookDate,
                                StartDate = b.StartDate,
                                EndDate = b.EndDate,
                                Adults = b.Adults,
                                Children = b.Children,
                                Price = b.Payments.Sum(p => p.Price)
                            })
                            .ToList()
                    },
                    ReservationRequest = request
                })
                .FirstAsync();
        }
    }
}
