using EventManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventManager.Infrastructure.Persistence;

public class EventManagerDbContext : DbContext
{
    public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options)
    {

    }

    public DbSet<Event> Events => Set<Event>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Speaker> Speakers => Set<Speaker>();
    public DbSet<Participant> Participants => Set<Participant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}