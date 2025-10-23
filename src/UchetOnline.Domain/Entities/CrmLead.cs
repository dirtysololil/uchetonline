using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     CRM-лид.
/// </summary>
public class CrmLead : BaseEntity
{
    [MaxLength(128)]
    public string CompanyName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string ContactName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(32)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(128)]
    public string LeadSource { get; set; } = string.Empty;

    public Guid? ResponsibleEmployeeId { get; set; }
        = null;

    public Employee? ResponsibleEmployee { get; set; }
        = null;
}
