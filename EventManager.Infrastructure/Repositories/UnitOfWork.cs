using EventManager.Application.Interfaces;
using EventManager.Infrastructure.Persistence;

namespace EventManager.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly EventManagerDbContext _context;

    public UnitOfWork(EventManagerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
}
