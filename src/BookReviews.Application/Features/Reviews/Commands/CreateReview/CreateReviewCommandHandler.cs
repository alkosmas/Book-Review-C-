using MediatR;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Exceptions;
using BookReviews.Domain.Entities;

namespace BookReviews.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateReviewCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.BookId, cancellationToken);
            if (book == null) 
                throw new NotFoundException(nameof(Book), request.BookId);

            var userId = _currentUserService.UserId; 
            if (string.IsNullOrEmpty(userId)) 
                throw new UnauthorizedException("User not authenticated");

            var review = new Review
            {
                BookId = request.BookId,
                Content = request.Content,
                Rating = request.Rating,
                UserId = userId,

            };

            await _context.Reviews.AddAsync(review, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}