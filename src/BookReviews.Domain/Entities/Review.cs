using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviews.Domain.Entities
{
    public class Review
    {
        public string Content{ get; set;}
        public int Rating{ get; set; }
        public int BookId{ get; set; }
        public string UserId { get; set; }
        public Book Book { get; set; }
        public IUser User { get; set; }
        public ICollection<ReviewVote> ReviewVotes = new List<ReviewVote>();
    }
}

