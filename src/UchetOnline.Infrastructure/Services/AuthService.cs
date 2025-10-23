using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Data;

namespace UchetOnline.Infrastructure.Services;

/// <summary>
///     Service responsible for authentication and user management.
/// </summary>
public class AuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly UchetOnlineContext _context;

    public AuthService(UchetOnlineContext context, ILogger<AuthService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<User?> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.UserName == userName && u.IsActive, cancellationToken);

        if (user == null)
        {
            _logger.LogWarning("Failed login attempt for {UserName}", userName);
            return null;
        }

        if (!PasswordHasher.Verify(password, user.PasswordHash))
        {
            _logger.LogWarning("Invalid password for {UserName}", userName);
            return null;
        }

        return user;
    }

    public async Task<User> EnsureAdminAsync(string userName, string password, CancellationToken cancellationToken = default)
    {
        var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        if (existing != null)
        {
            return existing;
        }

        var adminRole = await _context.Roles.FirstAsync(r => r.Code == "admin", cancellationToken);

        var user = new User
        {
            UserName = userName,
            DisplayName = "Администратор",
            PasswordHash = PasswordHasher.HashPassword(password)
        };

        user.UserRoles.Add(new UserRole { User = user, Role = adminRole });

        if (_context.Database.IsRelational())
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        else
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return user;
    }
}
