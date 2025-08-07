using EventManager.Domain.Entities;
using EventManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EventManager.Application.Interfaces;

namespace EventManager.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventManagerDbContext _context;

    public EventRepository(EventManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Event entity)
    {
        await _context.Events.AddAsync(entity);
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _context.Events
            .Include(x => x.Speaker)
            .Include(x => x.Reservations)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(Event entity)
    {
        _context.Events.Update(entity);
        return Task.CompletedTask;
    }

    public async Task<List<Event>> GetAllAsync() {
        return await _context.Events.ToListAsync();
    }
}