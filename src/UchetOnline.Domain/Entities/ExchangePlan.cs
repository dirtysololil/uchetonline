using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     План обмена данными.
/// </summary>
public class ExchangePlan : BaseEntity
{
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(128)]
    public string CronExpression { get; set; } = string.Empty;

    public DateTime? LastRunUtc { get; set; }
        = null;
}
