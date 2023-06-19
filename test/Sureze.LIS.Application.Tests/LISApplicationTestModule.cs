using Volo.Abp.Modularity;

namespace Sureze.LIS;

[DependsOn(
    typeof(LISApplicationModule),
    typeof(LISDomainTestModule)
    )]
public class LISApplicationTestModule : AbpModule
{

}
