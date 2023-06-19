using Sureze.LIS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sureze.LIS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LISEntityFrameworkCoreModule),
    typeof(LISApplicationContractsModule)
    )]
public class LISDbMigratorModule : AbpModule
{

}
