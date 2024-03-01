using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Unit.Tests;

namespace DoctorAppointment.Services.Doctors;

public class DoctorAppService : DoctorService
{
    private readonly DoctorRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public DoctorAppService(
        DoctorRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(AddDoctorDto dto)
    {
        var nationalCodeExists = _repository.NationalCodeExists(dto.NationalCode);
        if (nationalCodeExists)
        {
            throw new DoctorNationalCodeExistsException();
        }
        var doctor = new Doctor
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Field = dto.Field,
            NationalCode = dto.NationalCode
        };

        _repository.Add(doctor);
        await _unitOfWork.Complete();
    }

    public async Task Delete(int id)
    {
        _repository.Delete(id);
        await _unitOfWork.Complete();
    }

    public async Task<List<GetDoctorResponseDto>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Update(int id, UpdateDoctorDto dto)
    {
        var doctor = await _repository.FindById(id);
        if (doctor is null)
        {
            throw new DoctorDoesNotExistException();
        }
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Field = dto.Field;

        await _unitOfWork.Complete();
    }
}