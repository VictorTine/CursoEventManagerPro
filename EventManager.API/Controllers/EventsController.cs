using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventManager.Application.Events.Commands.CreateEvent;

namespace EventManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    // Endpoint futuro
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(); // Placeholder
    }
}
