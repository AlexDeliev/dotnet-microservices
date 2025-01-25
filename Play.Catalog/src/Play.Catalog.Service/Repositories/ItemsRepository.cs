using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public class ItemsRepository : IItemsRepository
    {

        private const string collectionName = "items";

        private readonly IMongoCollection<Item> dbCollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        // The ItemsRepository constructor initializes the MongoDB client and database, and gets the items collection.
        public ItemsRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Catalog");
            dbCollection = database.GetCollection<Item>(collectionName);
        }

        // The GetAllAsync method retrieves all items from the items collection.
        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        // The GetAsync method retrieves an item from the items collection by its ID.
        public async Task<Item> GetAsync(Guid id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        // The CreateAsync method inserts a new item into the items collection.
        public async Task CreateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        // The UpdateAsync method updates an item in the items collection.
        public async Task UpdateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Item> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        // The RemoveAsync method removes an item from the items collection by its ID.
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}