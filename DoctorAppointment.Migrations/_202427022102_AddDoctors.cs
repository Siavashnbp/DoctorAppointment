using FluentMigrator;

namespace DoctorAppointment.Migrations;

[Migration(202427022102)]
public class _202427022102_AddDoctors : Migration
{
    public override void Up()
    {
        Create.Table("Doctors")
            .WithColumn("Id").AsInt32().Identity().NotNullable()
            .WithColumn("FirstName").AsString(50).NotNullable()
            .WithColumn("LastName").AsString(50).NotNullable()
            .WithColumn("Field").AsString(50).NotNullable()
            .WithColumn("NationalCode").AsString(11).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Doctors");
    }
}