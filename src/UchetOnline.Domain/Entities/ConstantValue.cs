using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Константы системы.
/// </summary>
public class ConstantValue : BaseEntity
{
    [MaxLength(128)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(512)]
    public string Value { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Description { get; set; } = string.Empty;
}
