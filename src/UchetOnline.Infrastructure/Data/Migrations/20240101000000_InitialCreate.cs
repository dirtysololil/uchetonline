using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UchetOnline.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AuditLogs",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                UserName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                ActionType = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                Details = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuditLogs", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "CatalogItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Category = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                UnitOfMeasure = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CatalogItems", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Constants",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Constants", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ExchangePlans",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CronExpression = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                LastRunUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ExchangePlans", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "IntegrationSettings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                IntegrationCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Endpoint = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                ApiKey = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IntegrationSettings", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Modules",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Modules", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Modules",
            columns: new[] { "Id", "Code", "Title", "Description", "CreatedAtUtc", "UpdatedAtUtc", "ConcurrencyToken" },
            values: new object[,]
            {
                { new Guid("00000000-0000-0000-0000-000000010001"), "inventory", "Склад", "Модуль Склад", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010002"), "accounting", "Бухгалтерия", "Модуль Бухгалтерия", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010003"), "sales", "Продажи", "Модуль Продажи", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010004"), "purchasing", "Закупки", "Модуль Закупки", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010005"), "hr", "Кадры", "Модуль Кадры", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010006"), "payroll", "Зарплата", "Модуль Зарплата", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010007"), "production", "Производство", "Модуль Производство", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010008"), "crm", "CRM", "Модуль CRM", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010009"), "catalogs", "Справочники", "Модуль Справочники", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010010"), "constants", "НСИ и константы", "Модуль НСИ и константы", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010011"), "exchange", "Планы обмена", "Модуль Планы обмена", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010012"), "reports", "Отчёты", "Модуль Отчёты", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null },
                { new Guid("00000000-0000-0000-0000-000000010013"), "chesnyznak", "Честный Знак", "Модуль Честный Знак", new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), null, null }
            });

        migrationBuilder.CreateTable(
            name: "ReportDefinitions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                Query = table.Column<string>(type: "text", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReportDefinitions", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Warehouses",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Warehouses", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                LastName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                MiddleName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Position = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                UserName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                DisplayName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                PasswordHash = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AccountingEntries",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                DebitAccount = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                CreditAccount = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                Currency = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                DocumentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DocumentNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                SourceDocumentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AccountingEntries", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "CrmLeads",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CompanyName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                ContactName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                LeadSource = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                ResponsibleEmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CrmLeads", x => x.Id);
                table.ForeignKey(
                    name: "FK_CrmLeads_Employees_ResponsibleEmployeeId",
                    column: x => x.ResponsibleEmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "PayrollDocuments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                Period = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                GrossAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                NetAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                Comment = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PayrollDocuments", x => x.Id);
                table.ForeignKey(
                    name: "FK_PayrollDocuments_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ProductionOrders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ProductName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                PlannedStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                PlannedFinish = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<int>(type: "integer", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductionOrders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "InventoryItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Sku = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Quantity = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                ReservedQuantity = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                UnitPrice = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                WarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                CatalogItemId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InventoryItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_InventoryItems_CatalogItems_CatalogItemId",
                    column: x => x.CatalogItemId,
                    principalTable: "CatalogItems",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_InventoryItems_Warehouses_WarehouseId",
                    column: x => x.WarehouseId,
                    principalTable: "Warehouses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ProductionOperations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ProductionOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                OperationName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                CompletedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ResponsibleEmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductionOperations", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProductionOperations_Employees_ResponsibleEmployeeId",
                    column: x => x.ResponsibleEmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_ProductionOperations_ProductionOrders_ProductionOrderId",
                    column: x => x.ProductionOrderId,
                    principalTable: "ProductionOrders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PurchaseOrders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SupplierName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                OrderDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "SalesOrders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CustomerName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                OrderDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SalesOrders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "InventoryTransactions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                InventoryItemId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                OperationType = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                Comment = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                RelatedDocumentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                table.ForeignKey(
                    name: "FK_InventoryTransactions_InventoryItems_InventoryItemId",
                    column: x => x.InventoryItemId,
                    principalTable: "InventoryItems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PurchaseOrderLines",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                CatalogItemId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PurchaseOrderLines", x => x.Id);
                table.ForeignKey(
                    name: "FK_PurchaseOrderLines_CatalogItems_CatalogItemId",
                    column: x => x.CatalogItemId,
                    principalTable: "CatalogItems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PurchaseOrderLines_PurchaseOrders_PurchaseOrderId",
                    column: x => x.PurchaseOrderId,
                    principalTable: "PurchaseOrders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "SalesOrderLines",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SalesOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                InventoryItemId = table.Column<Guid>(type: "uuid", nullable: false),
                Quantity = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                DiscountPercent = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                ConcurrencyToken = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SalesOrderLines", x => x.Id);
                table.ForeignKey(
                    name: "FK_SalesOrderLines_InventoryItems_InventoryItemId",
                    column: x => x.InventoryItemId,
                    principalTable: "InventoryItems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SalesOrderLines_SalesOrders_SalesOrderId",
                    column: x => x.SalesOrderId,
                    principalTable: "SalesOrders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "UserRoles",
            columns: table => new
            {
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                RoleId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    name: "FK_UserRoles_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UserRoles_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Code", "ConcurrencyToken", "CreatedAtUtc", "Title", "UpdatedAtUtc" },
            values: new object[,]
            {
                { new Guid("00000000-0000-0000-0000-000000000001"), "admin", null, new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), "Администратор", null },
                { new Guid("00000000-0000-0000-0000-000000000002"), "manager", null, new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), "Менеджер", null },
                { new Guid("00000000-0000-0000-0000-000000000003"), "accountant", null, new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), "Бухгалтер", null }
            });

        migrationBuilder.CreateIndex(
            name: "IX_CrmLeads_ResponsibleEmployeeId",
            table: "CrmLeads",
            column: "ResponsibleEmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_InventoryItems_CatalogItemId",
            table: "InventoryItems",
            column: "CatalogItemId");

        migrationBuilder.CreateIndex(
            name: "IX_InventoryItems_WarehouseId_Sku",
            table: "InventoryItems",
            columns: new[] { "WarehouseId", "Sku" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_InventoryTransactions_InventoryItemId",
            table: "InventoryTransactions",
            column: "InventoryItemId");

        migrationBuilder.CreateIndex(
            name: "IX_PayrollDocuments_EmployeeId",
            table: "PayrollDocuments",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_ProductionOperations_ProductionOrderId",
            table: "ProductionOperations",
            column: "ProductionOrderId");

        migrationBuilder.CreateIndex(
            name: "IX_ProductionOperations_ResponsibleEmployeeId",
            table: "ProductionOperations",
            column: "ResponsibleEmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_PurchaseOrderLines_CatalogItemId",
            table: "PurchaseOrderLines",
            column: "CatalogItemId");

        migrationBuilder.CreateIndex(
            name: "IX_PurchaseOrderLines_PurchaseOrderId",
            table: "PurchaseOrderLines",
            column: "PurchaseOrderId");

        migrationBuilder.CreateIndex(
            name: "IX_SalesOrderLines_InventoryItemId",
            table: "SalesOrderLines",
            column: "InventoryItemId");

        migrationBuilder.CreateIndex(
            name: "IX_SalesOrderLines_SalesOrderId",
            table: "SalesOrderLines",
            column: "SalesOrderId");

        migrationBuilder.CreateIndex(
            name: "IX_UserRoles_RoleId",
            table: "UserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_UserName",
            table: "Users",
            column: "UserName",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Roles_Code",
            table: "Roles",
            column: "Code",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AccountingEntries");

        migrationBuilder.DropTable(
            name: "AuditLogs");

        migrationBuilder.DropTable(
            name: "Constants");

        migrationBuilder.DropTable(
            name: "CrmLeads");

        migrationBuilder.DropTable(
            name: "ExchangePlans");

        migrationBuilder.DropTable(
            name: "IntegrationSettings");

        migrationBuilder.DropTable(
            name: "InventoryTransactions");

        migrationBuilder.DropTable(
            name: "Modules");

        migrationBuilder.DropTable(
            name: "PayrollDocuments");

        migrationBuilder.DropTable(
            name: "ProductionOperations");

        migrationBuilder.DropTable(
            name: "PurchaseOrderLines");

        migrationBuilder.DropTable(
            name: "ReportDefinitions");

        migrationBuilder.DropTable(
            name: "SalesOrderLines");

        migrationBuilder.DropTable(
            name: "UserRoles");

        migrationBuilder.DropTable(
            name: "InventoryItems");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "ProductionOrders");

        migrationBuilder.DropTable(
            name: "PurchaseOrders");

        migrationBuilder.DropTable(
            name: "SalesOrders");

        migrationBuilder.DropTable(
            name: "Roles");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "CatalogItems");

        migrationBuilder.DropTable(
            name: "Warehouses");
    }
}
