using Sureze.LIS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sureze.LIS.Permissions;

public class LISPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
    


        var LISGroup = context.AddGroup(LISPermissions.GroupName, L("Permission:LIS"));

        var booksPermission = LISGroup.AddPermission(LISPermissions.Patients.Default, L("Permission:Patients"));
        booksPermission.AddChild(LISPermissions.Patients.Create, L("Permission:Patients.Create"));
        booksPermission.AddChild(LISPermissions.Patients.Edit, L("Permission:Patients.Edit"));
        booksPermission.AddChild(LISPermissions.Patients.Delete, L("Permission:Patients.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LISResource>(name);
    }
}
