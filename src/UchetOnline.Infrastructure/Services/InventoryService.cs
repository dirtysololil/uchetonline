using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Data;

namespace UchetOnline.Infrastructure.Services;

/// <summary>
///     Сервис управления складом.
/// </summary>
public class InventoryService
{
    private readonly UchetOnlineContext _context;
    private readonly ILogger<InventoryService> _logger;

    public InventoryService(UchetOnlineContext context, ILogger<InventoryService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<List<InventoryItem>> GetItemsAsync(CancellationToken cancellationToken = default)
    {
        return _context.InventoryItems
            .Include(i => i.Warehouse)
            .Include(i => i.CatalogItem)
            .OrderBy(i => i.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ReserveAsync(Guid itemId, decimal quantity, Guid documentId, CancellationToken cancellationToken = default)
    {
        var transaction = await TryBeginTransactionAsync(cancellationToken);
        try
        {
            var item = await _context.InventoryItems.FirstOrDefaultAsync(i => i.Id == itemId, cancellationToken);
            if (item == null)
            {
                _logger.LogWarning("Inventory item {ItemId} not found", itemId);
                return false;
            }

            if (item.Quantity - item.ReservedQuantity < quantity)
            {
                _logger.LogWarning("Not enough stock for {Item}", item.Name);
                return false;
            }

            item.ReservedQuantity += quantity;
            _context.InventoryTransactions.Add(new InventoryTransaction
            {
                InventoryItemId = itemId,
                Quantity = -quantity,
                OperationType = "Reserve",
                RelatedDocumentId = documentId,
                Comment = "Резервирование товара"
            });

            await _context.SaveChangesAsync(cancellationToken);
            if (transaction != null)
            {
                await transaction.CommitAsync(cancellationToken);
            }

            return true;
        }
        catch
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync(cancellationToken);
            }

            throw;
        }
        finally
        {
            if (transaction != null)
            {
                await transaction.DisposeAsync();
            }
        }
    }

    public async Task<bool> ReleaseReserveAsync(Guid itemId, decimal quantity, Guid documentId, CancellationToken cancellationToken = default)
    {
        var transaction = await TryBeginTransactionAsync(cancellationToken);
        try
        {
            var item = await _context.InventoryItems.FirstOrDefaultAsync(i => i.Id == itemId, cancellationToken);
            if (item == null)
            {
                return false;
            }

            item.ReservedQuantity = Math.Max(0, item.ReservedQuantity - quantity);
            _context.InventoryTransactions.Add(new InventoryTransaction
            {
                InventoryItemId = itemId,
                Quantity = quantity,
                OperationType = "Release",
                RelatedDocumentId = documentId,
                Comment = "Снятие резерва"
            });

            await _context.SaveChangesAsync(cancellationToken);
            if (transaction != null)
            {
                await transaction.CommitAsync(cancellationToken);
            }

            return true;
        }
        catch
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync(cancellationToken);
            }

            throw;
        }
        finally
        {
            if (transaction != null)
            {
                await transaction.DisposeAsync();
            }
        }
    }

    /// <summary>
    ///     Starts a transaction only when the provider supports it (i.e. relational providers).
    /// </summary>
    private async Task<IDbContextTransaction?> TryBeginTransactionAsync(CancellationToken cancellationToken)
    {
        if (!_context.Database.IsRelational() || _context.Database.CurrentTransaction != null)
        {
            return null;
        }

        return await _context.Database.BeginTransactionAsync(cancellationToken);
    }
}
