using System;

// This file contains the contracts that will be used by the Play.Catalog service and the Play.Catalog.Api service.
namespace Play.Catalog.Contracts
{
    public record CatalogItemCreated(Guid ItemId, string Name, string Description);

    public record CatalogItemUpdated(Guid ItemId, string Name, string Description);

    public record CatalogItemDeleted(Guid ItemId);
}