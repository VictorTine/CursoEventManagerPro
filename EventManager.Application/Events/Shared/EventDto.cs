namespace EventManager.Application.Events.Shared;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime Date { get; set; }
    public string? SpeakerName { get; set; }
    public int TotalSeats { get; set; }
}
