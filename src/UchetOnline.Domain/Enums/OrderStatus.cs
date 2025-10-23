namespace UchetOnline.Domain.Enums;

/// <summary>
///     Общий статус документов заказов.
/// </summary>
public enum OrderStatus
{
    Черновик = 0,
    Утвержден = 1,
    Отгружен = 2,
    Закрыт = 3,
    Отменен = 4
}
