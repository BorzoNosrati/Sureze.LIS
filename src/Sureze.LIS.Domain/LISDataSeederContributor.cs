using Sureze.LIS.Commons;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Sureze.LIS;

public class LISDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{

    private readonly IRepository<Gender, int> _genderRep;
    private readonly IRepository<InActiveStatus, int> _inActiveStatusRep;

    public LISDataSeederContributor(
        IRepository<Gender, int> genderRep,
        IRepository<InActiveStatus, int> inActiveStatusRep)
    {
        _genderRep = genderRep;
        _inActiveStatusRep = inActiveStatusRep;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _genderRep.InsertManyAsync(new Gender[]
        {
            new Gender(){Name="M",Title="Male"},
            new Gender(){Name="F",Title="Female"},
            new Gender(){Name="O",Title="Other"},
            new Gender(){Name="U",Title="Unknown"},
        });

        await _inActiveStatusRep.InsertManyAsync(new InActiveStatus[] {
            new InActiveStatus(){Name="active",Title="Active"},
            new InActiveStatus(){Name="Inactive",Title="Inactive"},
            new InActiveStatus(){Name="InactiveDeceased",Title="Inactive-Deceased"}
        });
    }
}