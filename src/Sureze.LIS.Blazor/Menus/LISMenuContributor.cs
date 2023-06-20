using System.Threading.Tasks;
using Sureze.LIS.Localization;
using Sureze.LIS.MultiTenancy;
using Sureze.LIS.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Sureze.LIS.Blazor.Menus;

public class LISMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<LISResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                LISMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );
        if (await context.IsGrantedAsync(LISPermissions.Patients.Default))
        {
            context.Menu.AddItem(new ApplicationMenuItem(
                "LIS.Patients",
                l["Menu:Patients"],
                icon: "fas fa-hospital"
            ).AddItem(new ApplicationMenuItem(
                        "LIS.Patients.List",
                        l["Menu:Patients:List"],
                        url:"/patients"
                    ))
                    .AddItem(new ApplicationMenuItem(
                        "LIS.Patients.Register",
                        l["Menu:Patients:Register"],
                        url: "/RegisterPatient"
                    ))
                );
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        //return Task.CompletedTask;
    }
}
