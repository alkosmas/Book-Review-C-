using FluentValidation;
using BookReviews.Application.Features.Books.Commands;


namespace BookReviews.Application.Features.Books.Commands.UpdateBook 
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        private readonly string[] validGenres = new[] { "Fiction", "Non-Fiction", "Sci-Fi", "Fantasy", "Mystery" };

        public UpdateBookCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0); 

            RuleFor(p => p.Title)
                .NotEmpty().MaximumLength(200);
                
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