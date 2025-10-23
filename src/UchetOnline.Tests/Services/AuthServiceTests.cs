using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using UchetOnline.Infrastructure.Data;
using UchetOnline.Infrastructure.Services;
using Xunit;

namespace UchetOnline.Tests.Services;

public class AuthServiceTests
{
    [Fact]
    public async Task EnsureAdminCreatesUser()
    {
        var options = new DbContextOptionsBuilder<UchetOnlineContext>()
            .UseInMemoryDatabase("auth-tests")
            .Options;
        await using var context = new UchetOnlineContext(options);

        var service = new AuthService(context, NullLogger<AuthService>.Instance);
        var user = await service.EnsureAdminAsync("admin", "admin123!");

        Assert.NotNull(user);
        Assert.Equal("admin", user.UserName);
        Assert.True(PasswordHasher.Verify("admin123!", user.PasswordHash));
    }
}
