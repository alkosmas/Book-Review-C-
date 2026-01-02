using MediatR;
using BookReviews.Application.Features.Reviews.Dtos;

namespace BookReviews.Application.Features.Reviews.Queries.GetReviewsByBookId
{
    public record GetReviewsByBookIdQuery(int BookId) : IRequest<List<ReviewDto>>;
}