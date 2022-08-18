using System.Runtime.CompilerServices;
using Xunit;

namespace DatingFoss.Tests.TestUtils;
public class FactForAttribute : FactAttribute
{
    public FactForAttribute(string subjectName = "Constructor", [CallerMemberName] string testMethodName = "")
        => DisplayName = $"{subjectName}_{testMethodName}";
}
