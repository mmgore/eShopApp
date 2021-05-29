using Catalog.API.Entities;
using Catalog.API.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ICatalogContext _context;

        public CatalogRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
            => await _context.CatalogItems.Find(c => true).ToListAsync();

        public async Task CreateCatalogItem(CatalogItem item)
        {
            await _context.CatalogItems.InsertOneAsync(item);
        }

        public async Task<bool> DeleteCatalogItem(string id)
        {
            FilterDefinition<CatalogItem> filter = Builders<CatalogItem>.Filter.Eq(c => c.Id, id);
            var deleteResult = await _context.CatalogItems.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogByCategory(string category)
        {
            FilterDefinition<CatalogItem> filter = Builders<CatalogItem>.Filter.Eq(c => c.Category, category);

            return await _context.CatalogItems.Find(filter).ToListAsync();
        }

        public async Task<CatalogItem> GetCatalogById(string id)
        {
            FilterDefinition<CatalogItem> filter = Builders<CatalogItem>.Filter.Eq(c => c.Id, id);

            return await _context.CatalogItems.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCatalogItem(CatalogItem item)
        {
            var updateResult = await _context.CatalogItems.ReplaceOneAsync(c => c.Id == item.Id, item);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
