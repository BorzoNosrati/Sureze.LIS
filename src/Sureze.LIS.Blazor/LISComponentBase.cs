using Sureze.LIS.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Sureze.LIS.Blazor;

public abstract class LISComponentBase : AbpComponentBase
{
    protected LISComponentBase()
    {
        LocalizationResource = typeof(LISResource);
    }
}
