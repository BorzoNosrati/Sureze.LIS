using Volo.Abp.Settings;

namespace Sureze.LIS.Settings;

public class LISSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LISSettings.MySetting1));
    }
}
