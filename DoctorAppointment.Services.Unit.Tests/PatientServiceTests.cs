﻿using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Patients;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class PatientServiceTests
    {
        [Fact]
        public async Task Add_adds_patient_properly()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();

            var dto = AddPatientDtoFactory.Create();
            var sut = PatientServiceFactory.Create(context);

            await sut.Add(dto);

            var actual = readContext.Patients.Single();

            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.NationalCode.Should().Be(dto.NationalCode);
        }
        [Fact]
        public async Task Add_throws_PatientNationalCodeAlreadyExistsException_on_duplicate_national_code()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();

            var dto = AddPatientDtoFactory.Create();
            var patient = new PatientBuilder().PatientWithFirstName(dto.FirstName)
                .PatientWithLastName(dto.LastName)
                .PatientWithNationalCode(dto.NationalCode).Build();
            context.Save(patient);
            var sut = PatientServiceFactory.Create(context);

            var actual = async () => await sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<PatientNationalCodeExistsException>();
        }
        [Fact]
        public async Task Update_updates_patient_properly()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();

            var patient = new PatientBuilder().Build();
            context.Save(patient);
            var dto = UpdatePatientDtoFactory.Create();
            var sut = PatientServiceFactory.Create(context);

            await sut.Update(patient.Id, dto);

            var actual = readContext.Patients.Single();

            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.NationalCode.Should().Be(patient.NationalCode);
            actual.Id.Should().Be(patient.Id);
        }
        [Fact]
        public async Task Update_throws_PatientDoesNotExistException_on_not_found_patients()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();

            var dto = UpdatePatientDtoFactory.Create();
            var sut = PatientServiceFactory.Create(context);

            var actual = async () => await sut.Update(0, dto);

            await actual.Should().ThrowExactlyAsync<PatientDoesNotExistException>();
        }

    }
}
