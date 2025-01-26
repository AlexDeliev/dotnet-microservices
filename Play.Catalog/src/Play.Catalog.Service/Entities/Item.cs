using System;
using Play.Common;


namespace Play.Catalog.Service.Entities
{
    public class Item : IEntity
    {
        // The Id property is a Guid type, which is a unique identifier for each item.

        public Guid Id { get; set; }
        // The Name property is a string type, which is the name of the item.
        public string Name { get; set; }
        // The Description property is a string type, which is the description of the item.
        public string Description { get; set; }
        // The Price property is a decimal type, which is the price of the item.
        public decimal Price { get; set; }
        // The CreatedDate property is a DateTimeOffset type, which is the date and time when the item was created.
        public DateTimeOffset CreatedDate { get; set; }
    }
}