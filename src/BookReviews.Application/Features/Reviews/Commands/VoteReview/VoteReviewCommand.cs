using MediatR;

namespace BookReviews.Application.Features.Reviews.Commands.VoteReview
{
    public class VoteReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
        public bool IsUpVote { get; set; }
    }
}