using MediatR;

namespace BookReviews.Application.Features.Reviews.Commands.DeleteReview
{
    public record DeleteReviewCommand(int Id) : IRequest;
}