using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookingClone.Domain.Entities;

namespace BookingClone.Domain.Contracts;
public interface IAttractionReviewRepository : IGenericRepository<AttractionReview, int>
{
    Task<List<AttractionReview>> GetAll(CancellationToken ct = default);
}
