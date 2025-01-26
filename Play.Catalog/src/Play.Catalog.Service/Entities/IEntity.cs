using System;


namespace Play.Catalog.Service.Entities
{
    // The IEntity interface defines the Id property, which is a Guid type, for each entity.
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}