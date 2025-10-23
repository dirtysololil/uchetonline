using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Номенклатура на складе.
/// </summary>
public class InventoryItem : BaseEntity
{
    [MaxLength(128)]
    public required string Name { get; set; }

    [MaxLength(64)]
    public string Sku { get; set; } = string.Empty;

    public decimal Quantity { get; set; }
        = 0m;

    public decimal ReservedQuantity { get; set; }
        = 0m;

    public decimal UnitPrice { get; set; }
        = 0m;

    public Guid WarehouseId { get; set; }

    public Warehouse? Warehouse { get; set; }

    public Guid? CatalogItemId { get; set; }

    public CatalogItem? CatalogItem { get; set; }
}
