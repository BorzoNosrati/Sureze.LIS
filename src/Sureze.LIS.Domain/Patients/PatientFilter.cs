using System;

namespace Sureze.LIS.Patients
{
    public class PatientFilter
    {
        public string Filter { get; set; }

        public string Fullname { get; set; }
        public string NationalIDNumber { get; set; }
        public string MRN { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? InActiveStatusId { get; set; }
    }
}