using UchetOnline.Infrastructure.Services;
using Xunit;

namespace UchetOnline.Tests.Services;

public class PasswordHasherTests
{
    [Theory]
    [InlineData("admin123!")]
    [InlineData("пароль123")]
    public void HashAndVerify(string password)
    {
        var hash = PasswordHasher.HashPassword(password);
        Assert.True(PasswordHasher.Verify(password, hash));
        Assert.False(PasswordHasher.Verify(password + "x", hash));
    }
}
