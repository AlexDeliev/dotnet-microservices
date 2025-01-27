using System;
using Play.Common;

namespace Play.Inventory.Service.Entities
{
    // CatalogItem entity class that implements the IEntity interface
    public class CatalogItem : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }        
    }
} 
