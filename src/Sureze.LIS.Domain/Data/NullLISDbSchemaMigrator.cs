using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sureze.LIS.Data;

/* This is used if database provider does't define
 * ILISDbSchemaMigrator implementation.
 */
public class NullLISDbSchemaMigrator : ILISDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
