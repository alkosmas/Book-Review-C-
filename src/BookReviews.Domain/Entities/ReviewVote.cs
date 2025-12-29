
using System.Collections.Generic;
using BookReviews.Domain.Interfaces;


namespace BookReviews.Domain.Entities
{
    public class ReviewVote: BaseEntity
    {
        public bool IsUpVote{ get; set; } 
        public string UserId { get; set; } = string.Empty;
        public IUser User { get; set; } = null!;
        public int ReviewId{get; set;} 
        public Review Review{get; set;} = null!;
    }
}