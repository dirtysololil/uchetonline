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

Пример строки подключения:

```json
"Database": {
  "ConnectionString": "Host=localhost;Port=5432;Database=uchetonline;Username=postgres;Password=MySecurePassword"
}
```

Не забудьте заменить пароль на тот, что выбран при установке PostgreSQL.

## Пошаговый запуск на Windows (для новичков)

Ниже приведена инструкция «с нуля», рассчитанная на пользователя без опыта разработки.

1. **Скачайте проект.**
   - Нажмите зелёную кнопку **Code** на странице репозитория и выберите **Download ZIP**.
   - Распакуйте архив в удобную папку, например `C:\Projects\UchetOnline`.
2. **Установите .NET SDK 8.0.**
   - Перейдите на [официальную страницу загрузки](https://dotnet.microsoft.com/download/dotnet/8.0).
   - Скачайте установщик `dotnet-sdk-8.0.x-win-x64.exe` и запустите его двойным щелчком.
   - После установки откройте меню «Пуск», найдите **Командная строка** или **PowerShell** и выполните команду:

     ```powershell
     dotnet --version
     ```

     Если выводится номер версии (например, `8.0.100`), всё установлено правильно.
3. **Установите PostgreSQL.**
   - Скачайте установщик с [postgresql.org/download](https://www.postgresql.org/download/windows/).
   - Во время установки запомните пароль пользователя `postgres` и путь установки (по умолчанию `C:\Program Files\PostgreSQL\15\`).
   - Оставьте галочки на компонентах **pgAdmin** и **Command Line Tools**.
   - После установки откройте `pgAdmin` → подключитесь к серверу → создайте новую базу с именем `uchetonline` (правый клик по Databases → Create → Database).
4. **Настройте строку подключения.**
   - В проводнике найдите файл `src\UchetOnline.App\appsettings.json`.
   - Откройте его в Блокноте и замените значение `Database:ConnectionString`, указав свой пароль:

     ```json
     "ConnectionString": "Host=localhost;Port=5432;Database=uchetonline;Username=postgres;Password=ВАШ_ПАРОЛЬ"
     ```

     Сохраните файл.
5. **Примените миграции (подготовьте таблицы).**
   - Откройте меню «Пуск» → **PowerShell** → выполните команды:

     ```powershell
     cd C:\Projects\UchetOnline\src\UchetOnline.App
     dotnet tool install --global dotnet-ef
     dotnet ef database update --project ..\UchetOnline.Infrastructure\UchetOnline.Infrastructure.csproj --startup-project UchetOnline.App.csproj --context UchetOnline.Infrastructure.Data.UchetOnlineContext
     ```

     При первом запуске `dotnet tool install` установит утилиту миграций. Повторно выполнять команду не потребуется.
6. **Запустите приложение.**
   - В том же окне PowerShell выполните:

     ```powershell
     cd C:\Projects\UchetOnline\src
     dotnet run --project UchetOnline.App\UchetOnline.App.csproj
     ```

   - Появится окно входа. Используйте логин `admin` и пароль `admin123!`. При первом запуске администратор будет создан автоматически.
7. **Создайте исполняемый файл для запуска без PowerShell.**
   - Выполните публикацию:

     ```powershell
     dotnet publish UchetOnline.App\UchetOnline.App.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
     ```

   - Готовый `UchetOnline.App.exe` появится в папке `src\UchetOnline.App\bin\Release\net8.0-windows\win-x64\publish`. Создайте ярлык на рабочем столе для удобного запуска.
8. **(Необязательно) Запустите автоматические тесты.**
   - В PowerShell выполните:

     ```powershell
     dotnet test C:\Projects\UchetOnline\src\UchetOnline.sln
     ```

   - Все тесты работают без подключения к реальной базе данных.

Если при запуске возникают ошибки, проверьте:

- что служба PostgreSQL запущена (значок в `Services.msc` или окно pgAdmin);
- что строка подключения содержит правильный пароль и порт;
- что команды выполняются из папки `src` (иначе `dotnet` не найдёт проекты).

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
