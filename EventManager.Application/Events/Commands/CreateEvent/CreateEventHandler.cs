using AutoMapper;
using MediatR;
using EventManager.Application.Events.DTOs;
using EventManager.Domain.Entities;
using EventManager.Application.Interfaces;

namespace EventManager.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventDto>
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Date = request.Date,
            SpeakerId = request.SpeakerId,
            TotalSeats = request.TotalSeats,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(@event);

        return _mapper.Map<EventDto>(@event);
    }
}

