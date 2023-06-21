using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sureze.LIS.Commons;
using Sureze.LIS.Patients;
using System;
using System.Linq.Expressions;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Sureze.LIS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class LISDbContext :
    AbpDbContext<LISDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Patient> Patients { get; set; }

    #region Common Entities


    public DbSet<PrimaryProvider> PrimaryProviders { get; set; }
    public DbSet<InActiveStatus> InActiveStatuses { get; set; }
    public DbSet<AlternateIDType> AlternateIDTypes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Ethnicity> Ethnicities { get; set; }
    public DbSet<EducationLevel> EducationLevels { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }
    public DbSet<Citizen> Citizens { get; set; }
    public DbSet<Religion> Religions { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<PatientCategory> PatientCategories { get; set; }
    public DbSet<NamePrefix> NamePrefixes { get; set; }
    #endregion



    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public LISDbContext(DbContextOptions<LISDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LISConsts.DbTablePrefix + "YourEntities", LISConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
