using Labb_3_API.Data;
using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Interfaces
{
    public class LinkRepository : ILink
    {
        private readonly AppDbContext _context;

        public LinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }
    }
}
