using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Test.Tools.Infrastructure.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository
    {
        void Add(Patient patient);
        bool NationalCodeExists(string nationalCode);
    }
}
