using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models
{
    public class Link
    {
        [Key]
        public int LiId { get; set; }

        public string URL { get; set; }

        public int PersonInterestId { get; set; }

        public PersonInterest PersonInterest { get; set; }

        
    }
}
