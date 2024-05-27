using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;
public interface ICountryRepository : IGenericRepository<Country, int>
{
    Task<List<Country>> GetAll(CancellationToken ct = default);
}
