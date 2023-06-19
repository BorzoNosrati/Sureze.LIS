using Sureze.LIS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sureze.LIS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LISController : AbpControllerBase
{
    protected LISController()
    {
        LocalizationResource = typeof(LISResource);
    }
}
