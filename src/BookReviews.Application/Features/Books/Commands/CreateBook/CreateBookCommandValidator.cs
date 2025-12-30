using FluentValidation;
using BookReviews.Application.Features.Books.Commands.CreateBook;


namespace BookReviews.Application.Features.Books.Commands
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {

        private readonly string[] validGenres = new[] { "Fiction", "Non-Fiction", "Sci-Fi", "Fantasy", "Mystery" };

        public CreateBookValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters");
            
            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
            
            RuleFor(p => p.Genre)
                .NotEmpty()
                .Must(g => validGenres.Contains(g))
                .WithMessage("Genre must be one of: " + string.Join(", ", validGenres));

            RuleFor(p => p.PublishedYear)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
