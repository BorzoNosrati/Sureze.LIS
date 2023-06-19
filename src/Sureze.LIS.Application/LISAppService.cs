using System;
using System.Collections.Generic;
using System.Text;
using Sureze.LIS.Localization;
using Volo.Abp.Application.Services;

namespace Sureze.LIS;

/* Inherit your application services from this class.
 */
public abstract class LISAppService : ApplicationService
{
    protected LISAppService()
    {
        LocalizationResource = typeof(LISResource);
    }
}
