using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;

namespace Sureze.LIS.Patients;

public interface IPatientRepository: IRepository<Patient, int>
{
    public  Task<IQueryable<Patient>> CreateFilteredQueryAsync(PatientFilter input);
    
       
    
}