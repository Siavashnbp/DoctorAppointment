using DoctorAppointment.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Doctors
{
    public class DoctorBuilder
    {
        private readonly Doctor _doctor;
        public DoctorBuilder()
        {
            _doctor = new Doctor
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "dummy-field",
                NationalCode = "0000000000"
            };
        }
        public DoctorBuilder DoctorWithFirstName(string firstName)
        {
            _doctor.FirstName = firstName;
            return this;
        }
        public DoctorBuilder DoctorWithLastName(string lastName)
        {
            _doctor.LastName = lastName;
            return this;
        }
        public DoctorBuilder DoctorWithField(string field)
        {
            _doctor.Field = field;
            return this;
        }
        public DoctorBuilder DoctorWithNationalCode(string nationalCode)
        {
            _doctor.NationalCode = nationalCode;
            return this;
        }
        public Doctor Build() => _doctor;
    }
}
