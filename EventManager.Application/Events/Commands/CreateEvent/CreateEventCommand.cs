using EventManager.Application.Events.DTOs;
using MediatR;

namespace EventManager.Application.Events.Commands.CreateEvent;

public class CreateEventCommand : IRequest<EventDto>
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public Guid SpeakerId { get; set; }
    public int TotalSeats{ get; set; }
}