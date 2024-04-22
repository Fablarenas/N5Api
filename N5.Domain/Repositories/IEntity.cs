
namespace N5.Domain.Repositories
{
    public interface IEntity<T>
    {
        T Id { get; }

        dynamic Item { get; }
    }
}
