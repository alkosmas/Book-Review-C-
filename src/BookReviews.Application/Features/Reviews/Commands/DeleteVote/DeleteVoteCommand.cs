using MediatR;

namespace BookReviews.Application.Features.Reviews.Commands.DeleteVote
{
    public record DeleteVoteCommand(int ReviewId) : IRequest;
}