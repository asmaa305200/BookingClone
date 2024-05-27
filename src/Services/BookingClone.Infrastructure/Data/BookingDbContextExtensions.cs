using Bogus;
using BookingClone.Domain.Entities;
using BookingClone.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace BookingClone.Infrastructure.Data;

public static class BookingDbContextExtensions
{
    public static void Seed(this BookingDbContext context, ILogger<BookingDbContext> logger)
    {
        if (!context.Continents.Any())
        {
            context.Continents.AddRange(new[]
            {
                new Continent { Name = "Africa" },
                new Continent { Name = "Asia" },
                new Continent { Name = "North America" },
                new Continent { Name = "South America" },
                new Continent { Name = "Europe" },
            });
            context.SaveChanges();
        }

        if (!context.Countries.Any())
        {
            var countriesFaker = new Faker<Country>()
                .RuleFor(h => h.ContinentID, f => f.Random.Number(1, 5))
                .RuleFor(h => h.Name, f => f.Address.Country());

            context.Countries.AddRange(countriesFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.Cities.Any())
        {
            var citiesFaker = new Faker<City>()
                .RuleFor(h => h.CountryID, f => f.Random.Number(1, 20))
                .RuleFor(h => h.Name, f => f.Address.City());

            context.Cities.AddRange(citiesFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.Hotels.Any())
        {
            var hotelsFaker = new Faker<Hotel>()
                .RuleFor(h => h.Name, f => f.Company.CompanyName())
                .RuleFor(h => h.StarRating, f => f.Random.Number(1, 5))
                .RuleFor(h => h.Description, f => f.Company.CatchPhrase());

            context.Hotels.AddRange(hotelsFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.Rooms.Any())
        {
            var roomsFaker = new Faker<Room>()
                .RuleFor(h => h.RoomNumber, f => f.Company.CompanyName())
                .RuleFor(h => h.Description, f => f.Company.CatchPhrase())
                .RuleFor(h => h.BedCount, f => f.Random.Number(1, 3))
                .RuleFor(h => h.Price, f => f.Random.Decimal(100, 1000))
                .RuleFor(h => h.ViewType, f => f.Random.Enum<RoomViewType>())
                .RuleFor(h => h.IsAvailable, f => f.Random.Bool(0.5f))
                .RuleFor(h => h.HotelId, f => f.Random.Number(1, 20));

            context.Rooms.AddRange(roomsFaker.Generate(40));
            context.SaveChanges();
        }

        if (!context.Attractions.Any()) 
        {
            var attractionsFaker = new Faker<Attraction>()
                .RuleFor(a => a.Name, f => f.Commerce.ProductName())
                .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
                .RuleFor(a => a.AvailableTickets, f => f.Random.Int(1, 100))
                .RuleFor(a => a.TicketPrice, f => f.Random.Decimal(50, 500))
                .RuleFor(a => a.Duration, f => f.Date.FutureOffset().ToString());

            context.Attractions.AddRange(attractionsFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.AttractionReservations.Any())
        {
            var attractionReservationsFaker = new Faker<AttractionReservation>()
                .RuleFor(ar => ar.TotalCost, f => f.Random.Decimal(500, 5000))
                .RuleFor(ar => ar.Status, f => f.Random.Enum<ReservationStatus>())
                .RuleFor(ar => ar.TourStart, f => f.Date.SoonOffset());

            context.AttractionReservations.AddRange(attractionReservationsFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.RoomReservations.Any())
        {
            var roomReservationsFaker = new Faker<RoomReservation>()
                .RuleFor(ar => ar.TotalCost, f => f.Random.Decimal(500, 5000))
                .RuleFor(ar => ar.Status, f => f.Random.Enum<ReservationStatus>())
                .RuleFor(ar => ar.CheckIn, f => f.Date.SoonOffset())
                .RuleFor(ar => ar.CheckOut, f => f.Date.FutureOffset());

            context.RoomReservations.AddRange(roomReservationsFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.AttractionReviews.Any())
        {
            var attractionReviewsFaker = new Faker<AttractionReview>()
                .RuleFor(ar => ar.Comment, f => f.Lorem.Sentence())
                .RuleFor(ar => ar.AttractionID, f => f.Random.Number(1, 20))
                .RuleFor(ar => ar.ReviewDate, f => f.Date.RecentOffset());

            context.AttractionReviews.AddRange(attractionReviewsFaker.Generate(20));
            context.SaveChanges();
        }

        if (!context.HotelReviews.Any())
        {
            var hotelReviewsFaker = new Faker<HotelReview>()
                .RuleFor(ar => ar.HotelID, f => f.Random.Number(1, 20))
                .RuleFor(ar => ar.LocationRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.CleanlinessRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.StaffRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.ComfortRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.FacilitiesRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.StaffRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.ValueForMoneyRate, f => f.Random.Decimal(1, 10))
                .RuleFor(ar => ar.NegativeReview, f => f.Lorem.Sentence())
                .RuleFor(ar => ar.PositiveReview, f => f.Lorem.Sentence())
                .RuleFor(ar => ar.ReviewDate, f => f.Date.RecentOffset());

            context.HotelReviews.AddRange(hotelReviewsFaker.Generate(20));
            context.SaveChanges();
        }

        logger.LogInformation("Completed Seeding of context.");
    }
}