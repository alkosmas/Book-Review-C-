using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReviews.Domain.Interfaces;

namespace BookReviews.Domain.Entities
{
    public class Review
    {
        public string Content{ get; set;} = string.Empty;
        public int Rating{ get; set; } 
        public int BookId{ get; set; } 
        public string UserId { get; set; } = string.Empty;
        public Book Book { get; set; } = null!;
        public IUser User { get; set; } = null!;
        public ICollection<ReviewVote> ReviewVotes = new List<ReviewVote>();
    }
}

