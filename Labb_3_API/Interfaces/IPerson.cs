using Labb_3_API.Models;

namespace Labb_3_API.Interfaces
{
    public interface IPerson
    {
        Task <IEnumerable<Person>> GetAll();


        Task<IEnumerable<Interest>> GetInterestById(int id);

        Task<IEnumerable<Link>> GetLinksById(int id);
        Task<PersonInterest> AddNewInterest(int personId, int interestId);

    }
}
