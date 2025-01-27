using System;
using Play.Common;

namespace Play.Inventory.Service.Entities
{
    // InventoryItem entity class that implements the IEntity interface
    public class InventoryItem : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CatalogItemId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset AcquiredDate { get; set; }
    }
} 
