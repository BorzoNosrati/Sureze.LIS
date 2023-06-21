using Microsoft.EntityFrameworkCore;
using Sureze.LIS.EntityFrameworkCore;
using Sureze.LIS.Patients;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sureze.LIS.Repositories;

public class PatientRepository : EfCoreRepository<LISDbContext, Patient, int>, IPatientRepository
{
    public PatientRepository(IDbContextProvider<LISDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IQueryable<Patient>> CreateFilteredQueryAsync(PatientFilter input)
    {
        var dbset = await GetDbSetAsync();
        return dbset
            .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                x =>
                    EF.Functions.ILike(x.NationalIDNumber, $"%{input.Filter}%") ||
                    EF.Functions.ILike(x.MRN, $"%{input.Filter}%") ||
                    EF.Functions.ILike(x.FirstName + " " + x.LastName, $"%{input.Filter}%"))

            .WhereIf(!input.NationalIDNumber.IsNullOrWhiteSpace(), x =>
            EF.Functions.ILike(x.NationalIDNumber, $"%{input.NationalIDNumber}%"))

            .WhereIf(!input.MRN.IsNullOrWhiteSpace(), x =>
            EF.Functions.ILike(x.NationalIDNumber, $"%{input.MRN}%"))

            .WhereIf(!input.Fullname.IsNullOrWhiteSpace(), x =>
            EF.Functions.ILike(x.FirstName + " " + x.LastName, $"%{input.Fullname}%"))

             .WhereIf(input.InActiveStatusId.HasValue, x => x.InActiveStatusId == input.InActiveStatusId)
            .WhereIf(input.DateOfBirth.HasValue, x => x.DateOfBirth == input.DateOfBirth)
              ;
    }
}