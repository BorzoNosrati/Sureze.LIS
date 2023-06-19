using System.Threading.Tasks;

namespace Sureze.LIS.Data;

public interface ILISDbSchemaMigrator
{
    Task MigrateAsync();
}
