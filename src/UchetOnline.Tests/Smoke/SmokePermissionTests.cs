using Microsoft.EntityFrameworkCore;
using UchetOnline.Infrastructure.Data;
using Xunit;

namespace UchetOnline.Tests.Smoke;

public class SmokePermissionTests
{
    [Fact]
    public void ContextCanBeCreated()
    {
        var options = new DbContextOptionsBuilder<UchetOnlineContext>()
            .UseInMemoryDatabase("permissions-smoke")
            .Options;

        using var context = new UchetOnlineContext(options);

        Assert.NotNull(context);
    }
}
