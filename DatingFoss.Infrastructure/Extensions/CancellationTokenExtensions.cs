using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Extensions;
public static class CancellationTokenExtensions
{
    public static Task WaitUntilCancellation(this CancellationToken @this)
    {
        var tcs = new TaskCompletionSource();
        @this.Register(() => tcs.TrySetResult());
        return tcs.Task;
    }
}
