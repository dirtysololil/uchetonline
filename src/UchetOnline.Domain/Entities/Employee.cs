using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Сотрудник компании.
/// </summary>
public class Employee : BaseEntity
{
    [MaxLength(64)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(64)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(64)]
    public string MiddleName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string Position { get; set; } = string.Empty;

    public DateOnly HireDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public bool IsActive { get; set; } = true;

    public ICollection<PayrollDocument> PayrollDocuments { get; set; } = new List<PayrollDocument>();
}
