using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistence.EF.Doctors;

public class EFDoctorRepository : DoctorRepository
{
    private readonly EFDataContext _context;

    public EFDoctorRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public async void Delete(int id)
    {
        var doctor = await FindById(id);
        _context.Doctors.Remove(doctor);
    }

    public async Task<Doctor?> FindById(int id)
    {
        return await _context.Doctors.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<List<GetDoctorResponseDto>> GetAll()
    {
        return await _context.Doctors.Select(_ => new GetDoctorResponseDto
        {
            Id = _.Id,
            FirstName = _.FirstName,
            Lastame = _.LastName,
            Field = _.Field,
            NationalCode = _.NationalCode
        }).ToListAsync();
    }

    public bool NationalCodeExists(string nationalCode)
    {
        return _context.Doctors.Any(_ => _.NationalCode == nationalCode);
    }
}