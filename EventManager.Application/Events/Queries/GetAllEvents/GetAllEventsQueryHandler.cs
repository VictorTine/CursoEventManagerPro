using AutoMapper;
using MediatR;
using EventManager.Application.Events.DTOs;
using EventManager.Application.Interfaces;

namespace EventManager.Application.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventDto>>
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _repository.GetAllAsync();
            return _mapper.Map<List<EventDto>>(events);
        }
    }
}
