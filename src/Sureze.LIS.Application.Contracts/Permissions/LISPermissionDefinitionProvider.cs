using Sureze.LIS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sureze.LIS.Permissions;

public class LISPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LISPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LISPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LISResource>(name);
    }
}
