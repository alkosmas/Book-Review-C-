using MediatR;
using Microsoft.EntityFrameworkCore;
using BookReviews.Domain.Entities;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Exceptions;

namespace BookReviews.Application.Features.Reviews.Commands.DeleteReview
{

    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteReviewCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserService.UserId;
            if (currentUserId == null) throw new UnauthorizedException("User not authenticated");

            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (review == null)
            {
                throw new NotFoundException(nameof(Review), request.Id);
            }


            bool isOwner = review.UserId == currentUserId;
            bool isAdmin = _currentUserService.IsAdmin;

            if (!isOwner && !isAdmin)
            {
                throw new UnauthorizedException("You don't have permission to delete this review.");
            }

            _context.Reviews.Remove(review);
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}