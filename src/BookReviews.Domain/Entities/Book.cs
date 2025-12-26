using System.Collections.Generic;


namespace BookReviews.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set;}
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        public ICollection<Review> Reviews{ get; set; } = new List<Review>();
    }
}

