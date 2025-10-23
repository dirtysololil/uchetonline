using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Технический журнал аудита.
/// </summary>
public class AuditLog : BaseEntity
{
    [MaxLength(64)]
    public string UserName { get; set; } = string.Empty;

    [MaxLength(32)]
    public string ActionType { get; set; } = string.Empty;

    [MaxLength(512)]
    public string Details { get; set; } = string.Empty;
}
