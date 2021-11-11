using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API
{
    public class RepositoryBase<T> : IRepository<T> where T :IEntityBase
    {
        public readonly ICatalogContext<T> context;

        public RepositoryBase(ICatalogContext<T> context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<T>> GetItems()
        {
            return await context
                            .Items
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<T> GetItem(string id)
        {
            return await context
                           .Items
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task CreateItem(T item)
        {
            await context.Items.InsertOneAsync(item);
        }

        public async Task<bool> UpdateItem(T item)
        {
            var updateResult = await context
                                        .Items
                                        .ReplaceOneAsync(filter: g => g.Id == item.Id, replacement: item);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteItem(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await context
                                                .Items
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
