using MediatR;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Exceptions;
using BookReviews.Domain.Entities;

namespace BookReviews.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _context.Books.Remove(book); 
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}