using MediatR;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Domain.Entities;
using BookReviews.Application.Common.Exceptions;

namespace BookReviews.Application.Features.Books.Commands.UpdateBook 
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBookCommand request , CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
            {
                throw new NotFoundException($"book with {request.Id} doesn't exists.");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.PublishedYear = request.PublishedYear;
            book.Genre = request.Genre;
        
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}