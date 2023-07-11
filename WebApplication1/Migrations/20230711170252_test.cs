using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportCopy = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryResidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityOfDeparture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alcohol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietaryRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TshirtSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSpouse = table.Column<bool>(type: "bit", nullable: false),
                    SpouseFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpousePassportCopy = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SpousePassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseIssueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SpouseExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SpouseDateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SpouseNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseCountryResidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseCityOfDeparture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseAlcohol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseDietaryRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseTshirtSize = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
