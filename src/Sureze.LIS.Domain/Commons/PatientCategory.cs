﻿using Sureze.LIS.Patients;
using System.Collections.Generic;

namespace Sureze.LIS.Commons
{
    public class PatientCategory : CommonEntity
    {
        public HashSet<Patient> Patients { get; set; }
    }
}