using Sureze.LIS.Patients;
using System.Collections.Generic;

namespace Sureze.LIS.Commons
{
    public class Citizen : CommonEntity
    {
        public HashSet<Patient> Patients { get; set; }
    }
}