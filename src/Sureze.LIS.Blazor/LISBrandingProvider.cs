using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sureze.LIS.Blazor;

[Dependency(ReplaceServices = true)]
public class LISBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LIS";
}
