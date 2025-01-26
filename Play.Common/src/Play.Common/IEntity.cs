using System;


namespace Play.Common
{
    // The IEntity interface defines the Id property, which is a Guid type, for each entity.
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}