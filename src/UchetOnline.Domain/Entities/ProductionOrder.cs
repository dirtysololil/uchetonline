using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UchetOnline.Domain.Enums;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Производственный заказ.
/// </summary>
public class ProductionOrder : BaseEntity
{
    [MaxLength(128)]
    public string ProductName { get; set; } = string.Empty;

    public DateOnly PlannedStart { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public DateOnly? PlannedFinish { get; set; }
        = null;

    public ProductionStatus Status { get; set; } = ProductionStatus.Планируется;

    public ICollection<ProductionOperation> Operations { get; set; } = new List<ProductionOperation>();
}

/// <summary>
///     Операция в рамках производственного заказа.
/// </summary>
public class ProductionOperation : BaseEntity
{
    public Guid ProductionOrderId { get; set; }

    public ProductionOrder? ProductionOrder { get; set; }

    [MaxLength(128)]
    public string OperationName { get; set; } = string.Empty;

    public DateTime? CompletedAtUtc { get; set; }
        = null;

    public Guid? ResponsibleEmployeeId { get; set; }
        = null;

    public Employee? ResponsibleEmployee { get; set; }
        = null;
}
