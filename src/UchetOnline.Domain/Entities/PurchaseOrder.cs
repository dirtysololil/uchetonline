using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UchetOnline.Domain.Enums;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Документ закупки.
/// </summary>
public class PurchaseOrder : BaseEntity
{
    [MaxLength(128)]
    public string SupplierName { get; set; } = string.Empty;

    public DateTime OrderDateUtc { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.Черновик;

    public ICollection<PurchaseOrderLine> Lines { get; set; } = new List<PurchaseOrderLine>();
}

/// <summary>
///     Строка закупки.
/// </summary>
public class PurchaseOrderLine : BaseEntity
{
    public Guid PurchaseOrderId { get; set; }

    public PurchaseOrder? PurchaseOrder { get; set; }

    public Guid CatalogItemId { get; set; }

    public CatalogItem? CatalogItem { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }
}
