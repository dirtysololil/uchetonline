using System;
using System.ComponentModel.DataAnnotations;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Бухгалтерская проводка.
/// </summary>
public class AccountingEntry : BaseEntity
{
    [MaxLength(32)]
    public required string DebitAccount { get; set; }

    [MaxLength(32)]
    public required string CreditAccount { get; set; }

    public decimal Amount { get; set; }

    [MaxLength(32)]
    public string Currency { get; set; } = "RUB";

    public DateOnly DocumentDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    [MaxLength(64)]
    public string DocumentNumber { get; set; } = string.Empty;

    public Guid? SourceDocumentId { get; set; }
        = null;
}
