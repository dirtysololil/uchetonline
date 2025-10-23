using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UchetOnline.Domain.Enums;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Документ продажи.
/// </summary>
public class SalesOrder : BaseEntity
{
    [MaxLength(128)]
    public string CustomerName { get; set; } = string.Empty;

    public DateTime OrderDateUtc { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.Черновик;

    public ICollection<SalesOrderLine> Lines { get; set; } = new List<SalesOrderLine>();
}

/// <summary>
///     Строка документа продажи.
/// </summary>
public class SalesOrderLine : BaseEntity
{
    public Guid SalesOrderId { get; set; }

    public SalesOrder? SalesOrder { get; set; }

    public Guid InventoryItemId { get; set; }

    public InventoryItem? InventoryItem { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal DiscountPercent { get; set; }
        = 0m;
}
