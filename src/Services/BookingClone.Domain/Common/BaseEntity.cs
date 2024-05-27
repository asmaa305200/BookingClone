namespace BookingClone.Domain.Common;

/// <summary>
/// The base class for any Unique Entity
/// </summary>
/// <typeparam name="T">The Primitive type of the ID</typeparam>
public abstract class BaseEntity<T>
{
    public T ID { get; set; } = default!;
}
