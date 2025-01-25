using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    // The IItemsRepository interface defines the methods that the ItemsRepository class must implement.
    public interface IItemsRepository
    {
        Task<IReadOnlyCollection<Item>> GetAllAsync();
        Task<Item> GetAsync(Guid id);
        Task CreateAsync(Item entity);
        Task UpdateAsync(Item entity);
        Task RemoveAsync(Guid id);
    }
}