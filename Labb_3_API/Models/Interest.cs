using System.ComponentModel.DataAnnotations;

namespace Labb_3_API.Models
{
    public class Interest
    {
        [Key]
        public int IntId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }

    }
}
