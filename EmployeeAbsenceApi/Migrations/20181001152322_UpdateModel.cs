using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAbsenceApi.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Attendances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "Attendances",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attendances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Attendances",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentAnnualLeave",
                table: "AnnualLeaveUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAnnualLeave",
                table: "AnnualLeaveUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AnnualLeaveUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "AnnualLeavePermissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveUser_UserId",
                table: "AnnualLeaveUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualLeaveUser_Users_UserId",
                table: "AnnualLeaveUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveUser_Users_UserId",
                table: "AnnualLeaveUser");

            migrationBuilder.DropIndex(
                name: "IX_AnnualLeaveUser_UserId",
                table: "AnnualLeaveUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CurrentAnnualLeave",
                table: "AnnualLeaveUser");

            migrationBuilder.DropColumn(
                name: "TotalAnnualLeave",
                table: "AnnualLeaveUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnualLeaveUser");

            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "AnnualLeavePermissions");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Attendances",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "Attendances",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attendances",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
