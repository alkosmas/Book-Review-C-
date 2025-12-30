using MediatR;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Domain.Entities;


namespace BookReviews.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PublishedYear = request.PublishedYear,
                Genre = request.Genre
            };

            await _context.Books.AddAsync(book, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}