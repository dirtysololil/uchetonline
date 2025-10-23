using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Base class for all persisted entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    ///     Primary identifier.
    /// </summary>
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     Creation timestamp in UTC.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Modification timestamp in UTC.
    /// </summary>
    public DateTime? UpdatedAtUtc { get; set; }
        = DateTime.UtcNow;

    /// <summary>
    ///     Token used for optimistic concurrency.
    /// </summary>
    [Timestamp]
    public byte[]? ConcurrencyToken { get; set; }
        = Array.Empty<byte>();
}
