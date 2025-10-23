using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Системный пользователь.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    ///     Уникальное имя пользователя (логин).
    /// </summary>
    [MaxLength(64)]
    public required string UserName { get; set; }

    /// <summary>
    ///     Отображаемое имя.
    /// </summary>
    [MaxLength(128)]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    ///     Хэш пароля (PBKDF2/BCrypt).
    /// </summary>
    [MaxLength(512)]
    public required string PasswordHash { get; set; }

    /// <summary>
    ///     Флаг активности.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    ///     Навигационное свойство для ролей.
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
