using BookingClone.Domain.Contracts;
using BookingClone.Infrastructure.Data;
using BookingClone.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingClone.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingDbContext>(o =>
        o.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), c =>
            c.EnableRetryOnFailure(3)));

        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IRoomReservationRepository, RoomReservationRepository>()
            .AddScoped<IAttractionReservationRepository, AttractionReservationRepository>()
            .AddScoped<IAttractionRepository, AttractionRepository>()
            .AddScoped<IRoomRepository, RoomRepository>()
            .AddScoped<IHotelRepository, HotelRepository>()
            .AddScoped<ICityRepository, CityRepository>()
            .AddScoped<IContinentRepository, ContinentRepository>()
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<IHotelReviewRepository, HotelReviewRepository>()
            .AddScoped<IAttractionReviewRepository, AttractionReviewRepository>();

        return services;
    }
}