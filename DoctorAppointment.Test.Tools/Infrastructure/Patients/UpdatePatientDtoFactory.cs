using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Patients
{
    public static class UpdatePatientDtoFactory
    {
        public static UpdatePatientDto Create()
        {
            return new UpdatePatientDto
            {
                FirstName = "updated-dummy-first-name",
                LastName = "updated-dummy-last-name"
            };
        }
    }
}
