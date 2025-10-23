namespace UchetOnline.Domain.Enums;

/// <summary>
///     Статус производственных заказов.
/// </summary>
public enum ProductionStatus
{
    Планируется = 0,
    ВПроизводстве = 1,
    Завершен = 2,
    Приостановлен = 3
}
