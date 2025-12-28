using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviews.Domain.Entities

{
    public class Book : BaseEntity
    {
        public string? Title { get; set; } = string.Empty;
        public string? Author { get; set;} =string.Empty;
        public int? PublishedYear { get; set; }
        public string? Genre { get; set; } =string.Empty;
        public ICollection<Review> Reviews{ get; set; } = new List<Review>();
    }
}

