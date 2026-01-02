using MediatR;
using Microsoft.EntityFrameworkCore;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Exceptions;

namespace BookReviews.Application.Features.Reviews.Commands.DeleteVote
{
    public class DeleteVoteCommandHandler : IRequestHandler<DeleteVoteCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteVoteCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task Handle(DeleteVoteCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) throw new UnauthorizedException("User not authenticated");

            var vote = await _context.ReviewVotes
                .FirstOrDefaultAsync(v => v.ReviewId == request.ReviewId && v.UserId == userId, cancellationToken);

            if (vote == null)
            {
                throw new NotFoundException("You haven't voted for this review.");
            }

            _context.ReviewVotes.Remove(vote);
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}