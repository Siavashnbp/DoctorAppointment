﻿namespace DoctorAppointment.Services.Doctors.Contracts.Dto
{
    public class GetDoctorResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastame { get; set; }
        public string Field { get; set; }
        public string NationalCode { get; set; }
    }
}