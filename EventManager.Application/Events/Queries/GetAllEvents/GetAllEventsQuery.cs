using EventManager.Application.Events.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EventManager.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<List<EventDto>>
    {
    }
}
