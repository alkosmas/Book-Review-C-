using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookReviews.Application.Features.Books.Commands.CreateBook;
using Microsoft.AspNetCore.Authorization;


[Route("api/[controller]")]
[ApiController]

public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok("Not implemented yet");
    }
}