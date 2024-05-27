using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Contracts;
using BookingClone.Domain.Entities;
using BookingClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Infrastructure.Repositories;
public class CountryRepository : GenericRepository<Country, int>, ICountryRepository
{
    public CountryRepository(BookingDbContext context) : base(context)
    {
    }

    public async Task<List<Country>> GetAll(CancellationToken ct = default)
     => await _db.ToListAsync(ct);
}
