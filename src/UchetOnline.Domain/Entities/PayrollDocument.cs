using System;
using System.ComponentModel.DataAnnotations;
using UchetOnline.Domain.Enums;

namespace UchetOnline.Domain.Entities;

/// <summary>
///     Документ начисления/выплаты зарплаты.
/// </summary>
public class PayrollDocument : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public DateOnly Period { get; set; } = new(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);

    public decimal GrossAmount { get; set; }

    public decimal NetAmount { get; set; }

    public PayrollStatus Status { get; set; } = PayrollStatus.Подготовлен;

    [MaxLength(256)]
    public string Comment { get; set; } = string.Empty;
}
