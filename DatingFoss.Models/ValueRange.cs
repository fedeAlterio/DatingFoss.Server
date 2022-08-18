namespace DatingFoss.Domain;
public class ValueRange<T> where T : IComparable<T>
{
    public T? Start { get; init; }
    public T? End { get; init; }
}
