using MediatR;

namespace BookReviews.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public int BookId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}