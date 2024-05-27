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
public class ContinentRepository : GenericRepository<Continent, int>, IContinentRepository
{
    public ContinentRepository(BookingDbContext context) : base(context)
    {
    }


   public async Task<List<Continent>> GetAll(CancellationToken ct)
       => await _db.ToListAsync(ct);
    
     

}
