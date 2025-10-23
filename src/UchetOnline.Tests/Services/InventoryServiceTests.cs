using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Data;
using UchetOnline.Infrastructure.Services;
using Xunit;

namespace UchetOnline.Tests.Services;

public class InventoryServiceTests
{
    [Fact]
    public async Task ReserveFailsWhenInsufficientStock()
    {
        var options = new DbContextOptionsBuilder<UchetOnlineContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        await using var context = new UchetOnlineContext(options);

        var warehouse = new Warehouse { Name = "Основной" };
        var item = new InventoryItem
        {
            Name = "Тестовый товар",
            Sku = "SKU-001",
            Quantity = 5,
            ReservedQuantity = 0,
            Warehouse = warehouse
        };

        context.Warehouses.Add(warehouse);
        context.InventoryItems.Add(item);
        await context.SaveChangesAsync();

        var service = new InventoryService(context, NullLogger<InventoryService>.Instance);
        var result = await service.ReserveAsync(item.Id, 10, Guid.NewGuid());

        Assert.False(result);
    }

    [Fact]
    public async Task ReserveSucceedsWithoutRelationalTransactions()
    {
        var options = new DbContextOptionsBuilder<UchetOnlineContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        await using var context = new UchetOnlineContext(options);

        var warehouse = new Warehouse { Name = "Основной" };
        var item = new InventoryItem
        {
            Name = "Товар",
            Sku = "SKU-002",
            Quantity = 20,
            ReservedQuantity = 0,
            Warehouse = warehouse
        };

        context.Warehouses.Add(warehouse);
        context.InventoryItems.Add(item);
        await context.SaveChangesAsync();

        var service = new InventoryService(context, NullLogger<InventoryService>.Instance);

        var result = await service.ReserveAsync(item.Id, 5, Guid.NewGuid());

        Assert.True(result);
        Assert.Equal(5, item.ReservedQuantity);
    }
}
