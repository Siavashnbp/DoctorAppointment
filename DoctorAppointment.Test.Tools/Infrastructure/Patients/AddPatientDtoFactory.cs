using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Patients
{
    public static class AddPatientDtoFactory
    {
        public static AddPatientDto Create()
        {
            return new AddPatientDto
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                NationalCode = "0000000000"
            };
        }
    }
}
