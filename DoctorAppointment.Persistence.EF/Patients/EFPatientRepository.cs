using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Services.Patients.Contracts;
using DoctorAppointment.Test.Tools.Infrastructure.Patients;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly EFDataContext _context;

        public EFPatientRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public bool NationalCodeExists(string nationalCode)
        {
            return _context.Patients.Any(_ => _.NationalCode == nationalCode);
        }

        async Task<Patient?> PatientRepository.FindById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}