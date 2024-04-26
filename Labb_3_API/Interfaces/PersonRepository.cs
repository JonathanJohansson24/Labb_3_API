using Labb_3_API.Data;
using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Labb_3_API.Interfaces
{
    public class PersonRepository : IPerson
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }
    

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }



        public async Task<IEnumerable<Interest>> GetInterestById(int id)
        {

            var interests = await _context.PersonInterests
                                .Where(pi => pi.PerId == id)
                                .Select(pi => pi.Interest)
                                .Distinct()
                                .ToListAsync();

            return interests;


            // För att hämta ut intresset samt personen, men blev dubbelt utskrivet så valde att inte ta det. 
            //var person = await _context.Persons
            //    .Include(p => p.PersonInterests)
            //    .ThenInclude(pi => pi.Interest)
            //    .FirstOrDefaultAsync(p => p.Id == id);
            //return person?.PersonInterests.Select(pi => pi.Interest).ToList() ?? new List<Interest>();
        }   

        public async Task<IEnumerable<Link>> GetLinksById(int id)
        {
            var links = await _context.PersonInterests
                               .Where(pi => pi.PerId == id)
                               .Include(pi => pi.Links)
                               .SelectMany(pi => pi.Links)
                               .ToListAsync();

            return links;
        }

        //public async Task<Person> GetSingle(int id)
        //{
        //    return await _context.Persons.Include(i => i.PersonInterests)
        //                                    .ThenInclude(i => i.Interest)
        //                                 .Include(l => l.PersonInterests)
        //                                    .ThenInclude(l => l.Links)
        //                                 .FirstOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<PersonInterest> AddNewInterest(int personId, int interestId)
        {
            var isExisting = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PerId == personId && pi.InterestId == interestId);

            if (isExisting != null) 
            {
                //The relation is already there

                return isExisting;
            }

            var newInterest = new PersonInterest
            {
                PerId = personId,
                InterestId = interestId
            };
            _context.PersonInterests.Add(newInterest);
            await _context.SaveChangesAsync();
            return newInterest;
        }

        public async Task<Link> AddLink(int personId, int interestId, string url)
        {
            // Checks if there is a existing relation in the personinterest
            var relation = await _context.PersonInterests
                                  .FirstOrDefaultAsync(pi => pi.PerId == personId && pi.InterestId == interestId);

            if(relation == null)
            {
                return null;
            }

            var newLink = new Link
            {
                URL = url,
                PersonInterestId = relation.PersonInterestId
            };

            _context.Links.Add(newLink);
            await _context.SaveChangesAsync();

            return newLink;
        }
    }
}
