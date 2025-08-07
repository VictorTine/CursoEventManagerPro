using EventManager.Domain.Common;

namespace EventManager.Domain.Entities;

public class Participant : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public Participant(string name, string email)
    {
        Name = name;
        Email = email;
    }
}