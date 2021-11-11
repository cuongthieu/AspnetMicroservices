using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API
{
    public class CatalogContext : ICatalogContext<Product>
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Items = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Items);
        }
        public IMongoCollection<Product> Items { get; }
    }
}
