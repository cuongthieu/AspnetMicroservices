using MongoDB.Driver;

namespace Catalog.API
{
    public interface ICatalogContext<T> where T : IEntityBase
    {
        IMongoCollection<T> Items { get; }
    }
}
