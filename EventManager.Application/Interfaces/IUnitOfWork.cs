namespace EventManager.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}