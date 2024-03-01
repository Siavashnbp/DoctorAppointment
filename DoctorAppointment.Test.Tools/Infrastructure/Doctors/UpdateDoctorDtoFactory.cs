using DoctorAppointment.Services.Doctors.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Doctors
{
    public static class UpdateDoctorDtoFactory
    {
        public static UpdateDoctorDto Create()
        {
            return new UpdateDoctorDto
            {
                FirstName = "updated-1-dummy-first-name",
                LastName = "updated-1-dummy-last-name",
                Field = "updated-1-dummy-field"
            };
        }
    }
}
