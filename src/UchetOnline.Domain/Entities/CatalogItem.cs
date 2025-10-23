using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Элемент справочника номенклатуры.
/// </summary>
public class CatalogItem : BaseEntity
{
    [MaxLength(64)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(128)]
    public string Category { get; set; } = string.Empty;

    [MaxLength(32)]
    public string UnitOfMeasure { get; set; } = "шт";

    public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public ICollection<PurchaseOrderLine> PurchaseLines { get; set; } = new List<PurchaseOrderLine>();
}
