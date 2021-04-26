using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            CatalogItems = database.GetCollection<CatalogItem>(configuration.GetValue<string>("DatabaseSettings:ConnectionName"));
        }
        public IMongoCollection<CatalogItem> CatalogItems { get; }
    }
}
