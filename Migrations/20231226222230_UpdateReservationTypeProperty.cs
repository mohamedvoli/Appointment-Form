using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment_form.Migrations
{
    public partial class UpdateReservationTypeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationType",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationType",
                table: "Appointments");
        }
    }
}
