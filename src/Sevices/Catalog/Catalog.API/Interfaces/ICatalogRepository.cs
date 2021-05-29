using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogById(string id);
        Task<IEnumerable<CatalogItem>> GetCatalogByCategory(string category);
        Task CreateCatalogItem(CatalogItem item);
        Task<bool> UpdateCatalogItem(CatalogItem item);
        Task<bool> DeleteCatalogItem(string id);
    }
}
