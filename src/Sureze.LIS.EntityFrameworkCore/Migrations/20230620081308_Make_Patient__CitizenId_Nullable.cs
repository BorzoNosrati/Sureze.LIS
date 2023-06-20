using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sureze.LIS.Migrations
{
    /// <inheritdoc />
    public partial class MakePatientCitizenIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Citizens_CitizenId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_InActiveStatuses_InActiveStatusId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "InActiveStatusId",
                table: "Patients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CitizenId",
                table: "Patients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Citizens_CitizenId",
                table: "Patients",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_InActiveStatuses_InActiveStatusId",
                table: "Patients",
                column: "InActiveStatusId",
                principalTable: "InActiveStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Citizens_CitizenId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_InActiveStatuses_InActiveStatusId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "InActiveStatusId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CitizenId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Citizens_CitizenId",
                table: "Patients",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_InActiveStatuses_InActiveStatusId",
                table: "Patients",
                column: "InActiveStatusId",
                principalTable: "InActiveStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
