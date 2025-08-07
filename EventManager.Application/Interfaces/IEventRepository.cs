using EventManager.Domain.Entities;

namespace EventManager.Application.Interfaces;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(Guid id);
    Task AddAsync(Event entity);
    Task UpdateAsync(Event entity);
    Task<List<Event>> GetAllAsync();
}