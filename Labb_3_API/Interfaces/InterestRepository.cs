using Labb_3_API.Data;
using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Interfaces
{
    public class InterestRepository : IInterest
    {
        private readonly AppDbContext _context;

        public InterestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _context.Interests.ToListAsync();
        }
    }
}
