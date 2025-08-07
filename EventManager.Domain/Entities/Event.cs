using System.Diagnostics;
using EventManager.Domain.Common;

namespace EventManager.Domain.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; } = null!;
    public DateTime Date { get; set; }
    public Guid SpeakerId { get; set; }
    public int TotalSeats { get; set; }
    public Speaker? Speaker { get; set; }

    private readonly List<Reservation> _reservations = new();
    public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

    public Event()
    {

    }

    public Event(string title, DateTime date, Guid speakerId, int totalSeats)
    {
        Title = title;
        Date = date;
        SpeakerId = speakerId;
        TotalSeats = totalSeats;
    }

    public void AddReservation(Guid participantId)
    {
        if (_reservations.Count >= TotalSeats)
            throw new InvalidOperationException("Evento Lotado.");

        var reservation = new Reservation(this.Id, participantId);
        _reservations.Add(reservation);
    }
}