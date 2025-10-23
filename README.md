# Учет Онлайн

Многофункциональная ERP-система «Учет Онлайн» с настольным интерфейсом WPF, построенная на .NET 8 и PostgreSQL. Приложение включает набор модулей (Склад, Бухгалтерия, Продажи, Закупки, Кадры, Зарплата, Производство, CRM, Справочники, НСИ, Планы обмена, Отчёты, интеграция с «Честным Знаком» и др.) и реализует архитектуру, готовую к расширению.

## Возможности

- Современное настольное приложение WPF (светлая тема в стиле ChatGPT).
- Поддержка PostgreSQL с использованием EF Core и миграций.
- Стартовые роли и администратор (логин `admin`, пароль `admin123!`).
- Навигация по модулям, шаблоны для новых разделов, заглушки печати и интеграции.
- Тесты на xUnit, разделение на проекты Domain / Infrastructure / App / Tests.
- CI/CD через GitHub Actions с запуском тестов и публикацией self-contained сборки.

## Требования

- .NET SDK 8.0 (или совместимый 7.0/6.0 при необходимости изменений).
- PostgreSQL 15+.
- Windows 10/11 для запуска WPF-клиента (сборка возможна только на Windows).

## Установка .NET SDK

| Платформа | Инструкция |
|-----------|------------|
| Windows   | Скачайте установщик с [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0) и выполните его. |
| Linux     | Следуйте [официальной документации](https://learn.microsoft.com/dotnet/core/install/linux) для вашего дистрибутива (apt, yum и т.д.). |
| macOS     | Установите пакет с сайта [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0) или через Homebrew (`brew install dotnet`). |

Проверьте установку командой:

```bash
dotnet --version
```

## Настройка базы данных

1. Установите PostgreSQL (например, через [официальный сайт](https://www.postgresql.org/download/)).
2. Создайте базу данных `uchetonline`:

```bash
psql -U postgres -c "CREATE DATABASE uchetonline;"
```

3. Примените миграции:

```bash
cd src/UchetOnline.App
 dotnet tool install --global dotnet-ef # при необходимости один раз
 dotnet ef database update --project ../UchetOnline.Infrastructure/UchetOnline.Infrastructure.csproj --startup-project UchetOnline.App.csproj --context UchetOnline.Infrastructure.Data.UchetOnlineContext
```

(Контекст и миграции находятся в проекте `UchetOnline.Infrastructure`.)

4. Настройте строку подключения в `src/UchetOnline.App/appsettings.json` или через переменные окружения (`Database:ConnectionString`).

## Запуск приложения

```bash
cd src
 dotnet run --project UchetOnline.App/UchetOnline.App.csproj
```

По умолчанию запускается окно входа. Используйте учетные данные `admin` / `admin123!`. При первом старте система автоматически создаст администратора, если его нет в базе.

### Публикация self-contained

```bash
cd src
 dotnet publish UchetOnline.App/UchetOnline.App.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```

Готовый `.exe` и зависимости появятся в `UchetOnline.App/bin/Release/net8.0-windows/win-x64/publish/`.

## Тестирование

```bash
cd src
 dotnet test UchetOnline.sln
```

Тесты не требуют реальной базы данных (используется InMemory provider), но в CI конфигурация PostgreSQL добавлена для будущих интеграционных проверок.

## CI/CD

Файл `.github/workflows/dotnet.yml` включает два задания:

- **build-windows** — сборка и публикация WPF-приложения на `windows-latest`.
- **test** — запуск `dotnet test` на `ubuntu-latest` с сервисом PostgreSQL 15, публикация артефактов тестов.

Используется действие `actions/setup-dotnet@v4`, что гарантирует наличие SDK и CLI на раннерах GitHub.

## Структура решений

```
src/
├── UchetOnline.App/             # WPF-клиент (MVVM, ресурсы, окна)
├── UchetOnline.Domain/          # Доменные сущности и перечисления
├── UchetOnline.Infrastructure/  # EF Core контекст, миграции, сервисы
├── UchetOnline.Tests/           # xUnit тесты (сервисы, инфраструктура)
└── UchetOnline.sln              # Солюшн с проектами
```

### Основные модули

- **Склад** — отображение остатков, резервирование, история движений.
- **Бухгалтерия** — проводки и шаблоны отчетов.
- **Продажи / Закупки** — заказ-наряды, строки документов.
- **Кадры / Зарплата** — сотрудники, выплаты, статусы.
- **Производство** — заказы и операции, ответственные сотрудники.
- **CRM** — работа с лидами.
- **Справочники / НСИ** — единые классификаторы и константы.
- **Планы обмена** — расписание синхронизаций.
- **Отчёты** — каталог описаний SQL/аналитики.
- **Честный Знак** — заглушка API маркировки (готова к расширению).

## Расширение и модификации

- **Новые поля**: добавьте свойства в соответствующие сущности (`UchetOnline.Domain`), обновите контекст и создайте новую миграцию (`dotnet ef migrations add`).
- **Новые модули**: создайте `ViewModel`, добавьте элемент в `NavigationService` и меню `MainViewModel`. Для UI опишите `DataTemplate` в `Resources/Styles.xaml`.
- **Отчёты**: добавьте записи в таблицу `ReportDefinitions`, реализуйте логику в `ReportService`.
- **Интеграции**: используйте `IntegrationSettings` и сервис `ChesnyZnakService` как пример.

## Стиль кода и документация

- В коде присутствует XML-комментирование (EN для технических деталей, RU для пользовательских строк).
- Для пользовательских сообщений UI и логов используется русский язык.
- Все публичные API и новые файлы сопровождайте комментариями.

## Вклад в проект

1. Форкните репозиторий и создайте ветку.
2. Выполните изменения, добавьте тесты.
3. Запустите `dotnet test` и `dotnet publish` (см. выше).
4. Создайте PR, описав изменения (на русском).

При возникновении вопросов воспользуйтесь issues/PR шаблонами или свяжитесь с командой разработки.

Удачной работы с «Учет Онлайн»!
