using Sureze.LIS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Sureze.LIS;

[DependsOn(
    typeof(LISEntityFrameworkCoreTestModule)
    )]
public class LISDomainTestModule : AbpModule
{

}
