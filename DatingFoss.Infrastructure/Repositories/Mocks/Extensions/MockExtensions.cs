using MockQueryable.EntityFrameworkCore;
using Moq;

namespace DatingFoss.Infrastructure.Repositories.Mocks.Extensions;
public static class MockExtensions
{
    public static Mock<IQueryable<TEntity>> BuildMock<TEntity>(this IQueryable<TEntity> data) where TEntity : class
    {
        var mock = new Mock<IQueryable<TEntity>>();
        var enumerable = new TestAsyncEnumerableEfCore<TEntity>(data);
        mock.As<IAsyncEnumerable<TEntity>>().ConfigureAsyncEnumerableCalls(enumerable);
        mock.ConfigureQueryableCalls(enumerable, data);
        return mock;
    }

    private static void ConfigureQueryableCalls<TEntity>(
        this Mock<IQueryable<TEntity>> mock,
        IQueryProvider queryProvider,
        IQueryable<TEntity> data) where TEntity : class
    {
        mock.Setup(m => m.Provider).Returns(queryProvider);
        mock.Setup(m => m.Expression).Returns(data?.Expression!);
        mock.Setup(m => m.ElementType).Returns(data?.ElementType!);
        mock.Setup(m => m.GetEnumerator()).Returns(() => data?.GetEnumerator()!);
    }

    private static void ConfigureAsyncEnumerableCalls<TEntity>(
        this Mock<IAsyncEnumerable<TEntity>> mock,
        IAsyncEnumerable<TEntity> enumerable)
    {
        mock.Setup(d => d.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(() => enumerable.GetAsyncEnumerator());
    }
}
