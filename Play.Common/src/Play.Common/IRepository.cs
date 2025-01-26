using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Play.Common
{
    // The IItemsRepository interface defines the methods that the ItemsRepository class must implement.
    public interface IRepository<T> where T : IEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(Guid id);
    }
}