using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Domain;
using DatingFoss.Infrastructure.Repositories.Mocks.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System.Collections.Concurrent;

namespace DatingFoss.Infrastructure.Repositories.Mocks;
public class MockCrud<T> : IQueryableCrud<T> where T : class
{
    // Private fields
    protected readonly List<T> _entities = new();
    private readonly Mock<IQueryable<T>> _entitiesQueryableMock;
    protected readonly object _locker = new();


    // Initialization
    public MockCrud()
    {
        _entitiesQueryableMock = _entities.AsQueryable().BuildMock();
    }



    // Properties
    public IQueryable<T> Entities => _entitiesQueryableMock.Object;



    // Core
    public Task<T> Add(T entity, CancellationToken _)
    {
        lock (_locker)
        {
            _entities.Add(entity);
            return Task.FromResult(entity);
        }
    }

    public Task ClearAll(CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            _entities.Clear();
            return Task.CompletedTask;
        }
    }

    public Task Delete(T entity, CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            _entities.Remove(entity);
            return Task.CompletedTask;
        }
    }

    public async Task Delete(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        foreach (var entity in entities.ToList())
            await Delete(entity, cancellationToken);
    }

    public virtual Task<T> Update(T entity, CancellationToken cancellationToken)
    {
        return Task.FromResult(entity);
    }
}
