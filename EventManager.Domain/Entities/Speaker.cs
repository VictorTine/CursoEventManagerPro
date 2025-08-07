using EventManager.Domain.Common;

namespace EventManager.Domain.Entities;

public class Speaker : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Bio { get; set; } = null!;
}