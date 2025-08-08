using EventManager.Application.Events.Commands.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventManager.Application.Events.Queries.GetAllEvents;
using EventManager.Application.Events.DTOs;

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
    public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllEventsQuery());
        return Ok(result);
    }
        
    [HttpGet]
    public async Task<ActionResult<List<EventDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllEventsQuery());
        return Ok(result);
    }



    
}
