using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Склад предприятия.
/// </summary>
public class Warehouse : BaseEntity
{
    [MaxLength(128)]
    public required string Name { get; set; }

    [MaxLength(256)]
    public string Address { get; set; } = string.Empty;

    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}
