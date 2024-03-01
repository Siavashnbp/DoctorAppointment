using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;

namespace DoctorAppointment.Services.Doctors.Contracts;

public interface DoctorRepository
{
    void Add(Doctor doctor);
    void Delete(int id);
    Task<Doctor?> FindById(int id);
    Task<List<GetDoctorResponseDto>> GetAll();
    bool NationalCodeExists(string nationalCode);
}