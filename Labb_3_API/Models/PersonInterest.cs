using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models
{
    public class PersonInterest
    {
        [Key]
        public int PersonInterestId { get; set; }
        public int PerId { get; set; }

        public Person Person { get; set; }

        public int InterestId { get; set; }

        public Interest Interest { get; set; }

        public ICollection<Link> Links { get; set; }
    }
}
