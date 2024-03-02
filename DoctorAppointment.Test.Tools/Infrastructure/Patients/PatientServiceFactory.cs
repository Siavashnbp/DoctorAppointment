using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Persistence.EF.Patients;
using DoctorAppointment.Services.Patients.Contracts;

namespace DoctorAppointment.Test.Tools.Infrastructure.Patients
{
    public static class PatientServiceFactory
    {
        public static PatientServices Create(EFDataContext context)
        {
            return new PatientAppServices(new EFPatientRepository(context), new EFUnitOfWork(context));
        }
    }
}
