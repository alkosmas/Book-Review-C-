using FluentValidation;

namespace BookReviews.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Review content is required")
                .MaximumLength(1000).WithMessage("Review content cannot exceed 1000 characters");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");

            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage("Invalid Book ID");
        }
    }
}