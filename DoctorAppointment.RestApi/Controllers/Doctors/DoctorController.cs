using System.ComponentModel.DataAnnotations;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestApi.Controllers.Doctors;

[ApiController, Route("api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _service;

    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task Add([Required] [FromBody] AddDoctorDto dto)
    {
        await _service.Add(dto);
    }
}