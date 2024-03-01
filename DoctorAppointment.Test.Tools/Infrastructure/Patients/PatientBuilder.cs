using DoctorAppointment.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Patients
{
    public class PatientBuilder
    {
        private readonly Patient _patient;
        public PatientBuilder()
        {
            _patient = new Patient
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                NationalCode = "0000000000"
            };
        }
        public PatientBuilder PatientWithFirstName(string firstName)
        {
            _patient.FirstName = firstName;
            return this;
        }
        public PatientBuilder PatientWithLastName(string lastName)
        {
            _patient.LastName = lastName;
            return this;
        }
        public PatientBuilder PatientWithNationalCode(string nationalCode)
        {
            _patient.NationalCode = nationalCode;
            return this;
        }
        public Patient Build() => _patient;
    }
}
