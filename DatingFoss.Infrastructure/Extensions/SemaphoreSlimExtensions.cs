using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Extensions;
internal static class SemaphoreSlimExtensions
{
    public static async ValueTask<DisposableRelease> WaitAsyncScoped(this SemaphoreSlim @this, CancellationToken cancellationToken = default)
    {
        await @this.WaitAsync(cancellationToken);
        return new DisposableRelease(@this);
    }

    public struct DisposableRelease : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim;

        public DisposableRelease(SemaphoreSlim semaphoreSlim) => _semaphoreSlim = semaphoreSlim;
        public void Dispose() => _semaphoreSlim.Release();
    }

}
