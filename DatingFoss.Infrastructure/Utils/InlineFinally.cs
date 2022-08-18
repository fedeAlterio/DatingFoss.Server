using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingFoss.Infrastructure.Utils;
public struct InlineFinally : IDisposable
{
    private Action _action;
    private InlineFinally(Action action) => _action = action;
    public static InlineFinally Do(Action action) => new(action);
    public void Dispose() => _action?.Invoke();
}
