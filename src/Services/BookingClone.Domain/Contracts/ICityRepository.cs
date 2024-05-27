using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;
public interface ICityRepository : IGenericRepository<City, int>
{
    Task<List<City>> GetAll(CancellationToken ct = default);
}
