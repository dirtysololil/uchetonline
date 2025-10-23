using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Движение по складу.
/// </summary>
public class InventoryTransaction : BaseEntity
{
    public Guid InventoryItemId { get; set; }

    public InventoryItem? InventoryItem { get; set; }

    public decimal Quantity { get; set; }

    [MaxLength(32)]
    public string OperationType { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Comment { get; set; } = string.Empty;

    public Guid? RelatedDocumentId { get; set; }
        = null;
}
