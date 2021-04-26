using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Infrastructure
{
    public interface ICatalogContext
    {
        IMongoCollection<CatalogItem> CatalogItems { get; }
    }
}
