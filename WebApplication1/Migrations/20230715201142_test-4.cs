using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSpouse",
                table: "Forms");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberAlcohol",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberCityOfDeparture",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberCountryResidence",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FamilyMemberDateOfBirth",
                table: "Forms",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberDietaryRequirements",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberEmail",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FamilyMemberExpiryDate",
                table: "Forms",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberFirstName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberFood",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberGender",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FamilyMemberIssueDate",
                table: "Forms",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberLastName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberMiddleName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberMobileNumber",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberNationality",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FamilyMemberPassportCopy",
                table: "Forms",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberPassportNumber",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FamilyMemberProfilePic",
                table: "Forms",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyMemberTshirtSize",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SpouseProfilePic",
                table: "Forms",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "UserProfilePic",
                table: "Forms",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyMemberAlcohol",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberCityOfDeparture",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberCountryResidence",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberDateOfBirth",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberDietaryRequirements",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberEmail",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberExpiryDate",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberFirstName",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberFood",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberGender",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberIssueDate",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberLastName",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberMiddleName",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberMobileNumber",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberNationality",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberPassportCopy",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberPassportNumber",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberProfilePic",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FamilyMemberTshirtSize",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "SpouseProfilePic",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserProfilePic",
                table: "Forms");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSpouse",
                table: "Forms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
