using AutoMapper;
using EventManager.Domain.Entities;
using EventManager.Application.Events.DTOs;

namespace EventManager.Application.Events.Mappings;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<Event, EventDto>().ReverseMap();
    }
}
