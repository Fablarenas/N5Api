using N5.Domain.Repositories;

namespace N5.Infraestructure.DbEntities
{
    public class Entity<T> : IEntity<T>
    {
        dynamic Item;
        string PropertyName { get; }
        public Entity(dynamic element, string propertyName)
        {
            Item = element;
            PropertyName = propertyName;
        }
        public T Id
        {
            get
            {
                return (T)Item.GetType().GetProperty(PropertyName).GetValue(Item, null);
            }
        }

        dynamic IEntity<T>.Item => Item;
    }
}
