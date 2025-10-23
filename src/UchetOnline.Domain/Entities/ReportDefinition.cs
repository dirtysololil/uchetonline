using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Описание отчёта.
/// </summary>
public class ReportDefinition : BaseEntity
{
    [MaxLength(128)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(512)]
    public string Description { get; set; } = string.Empty;

    public string Query { get; set; } = string.Empty;
}
