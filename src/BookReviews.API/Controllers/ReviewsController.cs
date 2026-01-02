using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using BookReviews.Application.Features.Reviews.Queries.GetReviewsByBookId;
using BookReviews.Application.Features.Reviews.Commands.CreateReview;


[Route("api/books/{bookId}/reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int bookId)
    {
        var result = await _mediator.Send(new GetReviewsByBookIdQuery(bookId));
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(int bookId, [FromBody] CreateReviewCommand command)
    {
        if (bookId != command.BookId) return BadRequest();
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}