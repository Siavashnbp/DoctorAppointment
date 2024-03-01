using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Services.Patients.Contracts;
using DoctorAppointment.Services.Unit.Tests;
using System.Runtime.CompilerServices;

namespace DoctorAppointment.Test.Tools.Infrastructure.Patients
{
    public class PatientAppServices : PatientServices
    {
        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppServices(PatientRepository patientRepository, UnitOfWork unitOfWork)
        {
            _repository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddPatientDto dto)
        {
            var nationalCodeExists = _repository.NationalCodeExists(dto.NationalCode);
            if (nationalCodeExists)
            {
                throw new PatientNationalCodeExistsException();
            }
            var patient = new Patient
            {
                NationalCode = dto.NationalCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
            _repository.Add(patient);
            await _unitOfWork.Complete();
        }
    }
}