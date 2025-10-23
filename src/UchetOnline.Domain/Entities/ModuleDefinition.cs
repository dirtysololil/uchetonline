using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Метаданные модулей системы.
/// </summary>
public class ModuleDefinition : BaseEntity
{
    [MaxLength(64)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Description { get; set; } = string.Empty;
}
