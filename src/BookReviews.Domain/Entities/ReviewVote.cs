
using System.Collections.Generic;


namespace BookReviews.Domain.Entities
{
    public class ReviewVote: BaseEntity
    {
        public bool IsUpVote{ get; set; }
        public IUser User { get; set; }
        public string UserId { get; set; }
        public int ReviewId{get; set;} 
        public Review Review{get; set;}
    }
}