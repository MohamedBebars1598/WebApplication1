﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DataBase;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230715201142_test-4")]
    partial class test4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.DataBase.Entities.FormEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alcohol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityOfDeparture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryResidence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DietaryRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ExpiryDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FamilyMemberAlcohol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberCityOfDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberCountryResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FamilyMemberDateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FamilyMemberDietaryRequirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FamilyMemberExpiryDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FamilyMemberFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("FamilyMemberIssueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FamilyMemberLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyMemberNationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FamilyMemberPassportCopy")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FamilyMemberPassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FamilyMemberProfilePic")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FamilyMemberTshirtSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Food")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("IssueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PassportCopy")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseAlcohol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseCityOfDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseCountryResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("SpouseDateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SpouseDietaryRequirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("SpouseExpiryDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SpouseFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseFood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("SpouseIssueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SpouseLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseMobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseNationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SpousePassportCopy")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SpousePassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SpouseProfilePic")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SpouseTshirtSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TshirtSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<byte[]>("UserProfilePic")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("WebApplication1.DataBase.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
