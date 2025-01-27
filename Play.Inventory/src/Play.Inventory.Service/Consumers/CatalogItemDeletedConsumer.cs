using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{
    public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
    {
        private readonly IRepository<CatalogItem> repository;
        // Injecting the repository in the constructor
        public CatalogItemDeletedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }
        // Implementing the Consume method
        public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
        {
            var message = context.Message;

            var item = await repository.GetAsync(message.ItemId);
            // If the item is not in the database, return
            if (item == null)
            {
                return;
            }
            // Remove the item from the database
            await repository.RemoveAsync(message.ItemId);
        }
    }
}