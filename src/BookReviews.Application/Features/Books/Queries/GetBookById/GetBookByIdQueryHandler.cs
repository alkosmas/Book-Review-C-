using MediatR;
using Microsoft.EntityFrameworkCore;
using Mapster;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Models;
using BookReviews.Domain.Entities;
using BookReviews.Application.Features.Books.Dtos;
using BookReviews.Application.Features.Books.Queries.GetBookById;
using BookReviews.Application.Common.Exceptions;

namespace BookReviews.Application.Features.Books.Queries.GetBooks
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IApplicationDbContext _context;

        public GetBookByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            
            return book.Adapt<BookDto>();

        }
    }
}