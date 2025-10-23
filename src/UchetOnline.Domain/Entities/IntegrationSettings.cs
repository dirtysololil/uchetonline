using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Настройки интеграций (включая Честный Знак).
/// </summary>
public class IntegrationSettings : BaseEntity
{
    [MaxLength(128)]
    public string IntegrationCode { get; set; } = string.Empty;

    [MaxLength(512)]
    public string Endpoint { get; set; } = string.Empty;

    [MaxLength(512)]
    public string ApiKey { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }
        = false;
}
