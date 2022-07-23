using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;
public class DbTest : IDisposable
{
    private string _databaseName = $"dbTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; }

    public DbTest()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<MyContext>(o =>
                o.UseMySql($"Server=localhost;Port=3306;Database={_databaseName};Uid=root;Pwd=secret"),
            ServiceLifetime.Transient);

        ServiceProvider = serviceCollection.BuildServiceProvider();
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context?.Database.EnsureCreated();
        }
    }
    public void Dispose()
    {
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context?.Database.EnsureDeleted();
        }
    }
}