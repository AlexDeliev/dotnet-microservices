using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumer
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        // Injecting the repository
        private readonly IRepository<CatalogItem> repository;

        // Injecting the repository in the constructor
        public CatalogItemCreatedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }

        // Implementing the Consume method
        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
        {
            // Getting the message from the context
            var message = context.Message;
            // Check if the item is already in the database
            var item = await repository.GetAsync(message.ItemId);

            // If the item is already in the database, return
            if (item != null)
            {
                return;
            }
            // Create a new item with the message data
            item = new CatalogItem
            {
                Id = message.ItemId,
                Name = message.Name,
                Description = message.Description
            };
            // Save the item in the database
            await repository.CreateAsync(item);
        }
    }
}