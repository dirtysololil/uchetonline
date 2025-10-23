using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UchetOnline.Domain.Entities;
using UchetOnline.Domain.Enums;

namespace UchetOnline.Infrastructure.Data;

/// <summary>
///     Главный контекст EF Core для системы Учет Онлайн.
/// </summary>
public class UchetOnlineContext : DbContext
{
    public UchetOnlineContext(DbContextOptions<UchetOnlineContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();

    public DbSet<AccountingEntry> AccountingEntries => Set<AccountingEntry>();

    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();

    public DbSet<SalesOrderLine> SalesOrderLines => Set<SalesOrderLine>();

    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();

    public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<PayrollDocument> PayrollDocuments => Set<PayrollDocument>();

    public DbSet<ProductionOrder> ProductionOrders => Set<ProductionOrder>();

    public DbSet<ProductionOperation> ProductionOperations => Set<ProductionOperation>();

    public DbSet<CrmLead> CrmLeads => Set<CrmLead>();

    public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();

    public DbSet<ConstantValue> Constants => Set<ConstantValue>();

    public DbSet<ExchangePlan> ExchangePlans => Set<ExchangePlan>();

    public DbSet<ReportDefinition> Reports => Set<ReportDefinition>();

    public DbSet<IntegrationSettings> Integrations => Set<IntegrationSettings>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    public DbSet<ModuleDefinition> Modules => Set<ModuleDefinition>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.UserName).IsUnique();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.Code).IsUnique();
        });

        modelBuilder.Entity<UserRole>()
            .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasIndex(e => new { e.WarehouseId, e.Sku }).IsUnique();
            entity.Property(e => e.UnitPrice).HasPrecision(18, 4);
            entity.Property(e => e.Quantity).HasPrecision(18, 4);
            entity.Property(e => e.ReservedQuantity).HasPrecision(18, 4);
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.Property(e => e.Quantity).HasPrecision(18, 4);
        });

        modelBuilder.Entity<AccountingEntry>(entity =>
        {
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.DocumentDate)
                .HasConversion(new DateOnlyConverter());
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.HireDate)
                .HasConversion(new DateOnlyConverter());
        });

        modelBuilder.Entity<PayrollDocument>(entity =>
        {
            entity.Property(e => e.Period)
                .HasConversion(new DateOnlyConverter());
            entity.Property(e => e.GrossAmount).HasPrecision(18, 2);
            entity.Property(e => e.NetAmount).HasPrecision(18, 2);
        });

        modelBuilder.Entity<ProductionOrder>(entity =>
        {
            entity.Property(e => e.PlannedStart)
                .HasConversion(new DateOnlyConverter());
            entity.Property(e => e.PlannedFinish)
                .HasConversion(new DateOnlyConverter());
        });

        modelBuilder.Entity<ProductionOperation>(entity =>
        {
            entity.HasOne(e => e.ResponsibleEmployee)
                .WithMany()
                .HasForeignKey(e => e.ResponsibleEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ModuleDefinition>().HasData(ModuleSeedData.All);
        modelBuilder.Entity<Role>().HasData(RoleSeedData.All);
    }

    private sealed class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter()
            : base(date => date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
                value => DateOnly.FromDateTime(DateTime.SpecifyKind(value, DateTimeKind.Utc)))
        {
        }
    }
}

internal static class ModuleSeedData
{
    public static readonly ModuleDefinition[] All =
    {
        Create("inventory", "Склад", "00000000-0000-0000-0000-000000010001"),
        Create("accounting", "Бухгалтерия", "00000000-0000-0000-0000-000000010002"),
        Create("sales", "Продажи", "00000000-0000-0000-0000-000000010003"),
        Create("purchasing", "Закупки", "00000000-0000-0000-0000-000000010004"),
        Create("hr", "Кадры", "00000000-0000-0000-0000-000000010005"),
        Create("payroll", "Зарплата", "00000000-0000-0000-0000-000000010006"),
        Create("production", "Производство", "00000000-0000-0000-0000-000000010007"),
        Create("crm", "CRM", "00000000-0000-0000-0000-000000010008"),
        Create("catalogs", "Справочники", "00000000-0000-0000-0000-000000010009"),
        Create("constants", "НСИ и константы", "00000000-0000-0000-0000-000000010010"),
        Create("exchange", "Планы обмена", "00000000-0000-0000-0000-000000010011"),
        Create("reports", "Отчёты", "00000000-0000-0000-0000-000000010012"),
        Create("chesnyznak", "Честный Знак", "00000000-0000-0000-0000-000000010013")
    };

    private static ModuleDefinition Create(string code, string title, string id) => new()
    {
        Id = Guid.Parse(id),
        Code = code,
        Title = title,
        Description = $"Модуль {title}"
    };
}

internal static class RoleSeedData
{
    public static readonly Role[] All =
    {
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Code = "admin",
            Title = "Администратор"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Code = "manager",
            Title = "Менеджер"
        },
        new()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Code = "accountant",
            Title = "Бухгалтер"
        }
    };
}
