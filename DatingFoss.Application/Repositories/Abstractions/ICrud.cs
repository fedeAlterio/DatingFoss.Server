using DatingFoss.Domain;

namespace DatingFoss.Application.Repositories.Abstractions;
public interface ICrud<T> where T : class
{
    Task<T> Add(T entity, CancellationToken cancellationToken);
    Task<T> Update(T entity, CancellationToken cancellationToken);
    Task Delete(T entity, CancellationToken cancellationToken);
    Task Delete(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task ClearAll(CancellationToken cancellationToken);
}
