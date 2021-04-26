using Catalog.API.Entities;
using Catalog.API.Interfaces;
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

        public async Task CreateCatalogItem(CatalogItem item)
        {
            await _context.CatalogItems.InsertOneAsync(item);
        }

        public Task<bool> DeleteCatalogItem(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogItem> GetCatalogItem()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCatalogItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }
    }
}
