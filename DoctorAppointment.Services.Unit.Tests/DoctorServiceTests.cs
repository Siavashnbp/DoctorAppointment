using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Doctors;
using FluentAssertions;

namespace DoctorAppointment.Services.Unit.Tests;

public class DoctorServiceTests
{
    [Fact]
    public async Task Add_adds_a_new_doctor_properly()
    {
        //arrange
        var dto = AddDoctorDtoFactory.Create();
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = DoctorServiceFactory.Create(context);

        //act
        await sut.Add(dto);

        //assert
        var actual = readContext.Doctors.Single();
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
    }

    [Fact]
    public async Task Update_updates_doctor_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor = new DoctorBuilder().Build();
        context.Save(doctor);
        var sut = DoctorServiceFactory.Create(context);
        var updateDto = UpdateDoctorDtoFactory.Create();

        //act
        await sut.Update(doctor.Id, updateDto);

        //assert
        var actual = readContext.Doctors.First(_ => _.Id == doctor.Id);
        actual.FirstName.Should().Be(updateDto.FirstName);
        actual.LastName.Should().Be(updateDto.LastName);
        actual.Field.Should().Be(updateDto.Field);
    }
    [Fact]
    public async Task Add_throws_NationalCodeAlreadyExistsException_on_duplicate_national_code()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();

        var doctor = new DoctorBuilder().Build();
        context.Save(doctor);
        var sut = DoctorServiceFactory.Create(context);
        var addDto = AddDoctorDtoFactory.Create();

        var actual = async () => await sut.Add(addDto);

        await actual.Should().ThrowExactlyAsync<DoctorNationalCodeExistsException>();
    }
    [Fact]
    public async Task GetAll_retrieves_all_doctors_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();

        var doctor1 = new DoctorBuilder().Build();
        context.Save(doctor1);
        var doctor2 = new DoctorBuilder().DoctorWithFirstName("second-dummy-first-name")
            .DoctorWithLastName("second-dummy-with-last-name")
            .DoctorWithNationalCode("0000000001")
            .DoctorWithField("second-dummy-field").Build();
        context.Save(doctor2);
        var sut = DoctorServiceFactory.Create(context);
        var getAllDtoResponse = await sut.GetAll();

        var actual = readContext.Doctors.ToList();
        actual.Should().HaveCount(context.Doctors.Count());

        actual[0].Id.Should().Be(doctor1.Id);
        actual[0].FirstName.Should().Be(doctor1.FirstName);
        actual[0].LastName.Should().Be(doctor1.LastName);
        actual[0].NationalCode.Should().Be(doctor1.NationalCode);
        actual[0].Field.Should().Be(doctor1.Field);

        actual[1].Id.Should().Be(doctor2.Id);
        actual[1].FirstName.Should().Be(doctor2.FirstName);
        actual[1].LastName.Should().Be(doctor2.LastName);
        actual[1].NationalCode.Should().Be(doctor2.NationalCode);
        actual[1].Field.Should().Be(doctor2.Field);
    }
    [Fact]
    public void Update_throws_DoctorDoesNotExistException_on_not_found_doctor()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();

        var dto = UpdateDoctorDtoFactory.Create();
        int updateId = 0;

        var sut = DoctorServiceFactory.Create(context);

        var actual = async () => await sut.Update(updateId, dto);

        actual.Should().ThrowExactlyAsync<DoctorDoesNotExistException>();
    }
    [Fact]
    public void Delete_deletes_doctor_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();

        var doctor = new DoctorBuilder().Build();
        context.Save(doctor);
        var sut = DoctorServiceFactory.Create(context);

        sut.Delete(doctor.Id);

        var actual = readContext.Doctors.Count();

        actual.Should().Be(0);
    }
}










