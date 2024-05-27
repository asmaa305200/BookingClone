using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;
public interface IContinentRepository : IGenericRepository<Continent, int>
{
    Task<List<Continent>> GetAll(CancellationToken ct = default);
}
