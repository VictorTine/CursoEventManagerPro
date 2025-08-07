using EventManager.Domain.Common;

namespace EventManager.Domain.Entities;

public class Reservation : BaseEntity
{
    public Guid EventId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public DateTime ReservedAt { get; private set; }

    public Reservation(Guid eventId, Guid participantId)
    {
        EventId = eventId;
        ParticipantId = participantId;
        ReservedAt = DateTime.UtcNow;
    }
}