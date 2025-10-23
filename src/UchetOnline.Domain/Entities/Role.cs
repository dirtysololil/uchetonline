using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Роль доступа.
/// </summary>
public class Role : BaseEntity
{
    /// <summary>
    ///     Код роли.
    /// </summary>
    [MaxLength(64)]
    public required string Code { get; set; }

    /// <summary>
    ///     Отображаемое имя роли.
    /// </summary>
    [MaxLength(128)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Навигационное свойство к пользователям.
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
