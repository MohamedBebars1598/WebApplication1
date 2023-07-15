using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using WebApplication1.DataBase;

namespace WebApplication1.Dtos
{
    public class FormDto
    {
        //profilePic
        public IFormFile UserProfilePic { get; set; }
        //⦁	First name
        public string FirstName { get; set; }   
        //⦁	Middle Name
        public string? MiddleName { get; set; }
        //⦁	Last Name
        public string LastName { get; set; }
        //⦁	Gender
        public string Gender { get; set; }
        //⦁	Passport copy 
        public IFormFile PassportCopy { get; set; }
        //⦁	Passport Number
        public string PassportNumber { get; set; }
        //⦁	Issued Date of Passport
        public DateTimeOffset IssueDate { get; set; }
        //⦁	Expiry Date of Passport
        public DateTimeOffset ExpiryDate { get; set; }
        //⦁	Date of Birth
        public DateTimeOffset DateOfBirth { get; set; }
        //⦁	Nationality
        public string Nationality { get; set; }
        //⦁	Country of Residence
        public string CountryResidence { get; set; }
        //⦁	City of departure(travelling to Baku from which city?
        public string CityOfDeparture { get; set; }
        //⦁	Mobile Number
        public string MobileNumber { get; set; }
        //⦁	Email Address
        public string Email { get; set; }
        //⦁	Alcohol Requirement YES or NO
        public string Alcohol { get; set; }
        //⦁	Food Preference VEG or NON VEG
        public string Food { get; set; }
        //⦁	Dietary requirements
        public string DietaryRequirements { get; set; }
        //⦁	T-shirt size
        public string TshirtSize { get; set; }
        //⦁	Spouse – yes or no, if yes same required information should pop up again
        public FormTypecs Type { get; set; }

        //spouse info incase it exists
        //profilePic
        public IFormFile? SpouseProfilePic { get; set; }
        //⦁	First name
        public string? SpouseFirstName { get; set; }
        //⦁	Middle Name
        public string? SpouseMiddleName { get; set; }
        //⦁	Last Name
        public string? SpouseLastName { get; set; }
        //⦁	Gender
        public string? SpouseGender { get; set; }
        //⦁	Passport copy 
        public IFormFile? SpousePassportCopy { get; set; }
        //⦁	Passport Number
        public string? SpousePassportNumber { get; set; }
        //⦁	Issued Date of Passport
        public DateTimeOffset? SpouseIssueDate { get; set; }
        //⦁	Expiry Date of Passport
        public DateTimeOffset? SpouseExpiryDate { get; set; }
        //⦁	Date of Birth
        public DateTimeOffset? SpouseDateOfBirth { get; set; }
        //⦁	Nationality
        public string? SpouseNationality { get; set; }
        //⦁	Country of Residence
        public string? SpouseCountryResidence { get; set; }
        //⦁	City of departure(travelling to Baku from which city?
        public string? SpouseCityOfDeparture { get; set; }
        //⦁	Mobile Number
        public string? SpouseMobileNumber { get; set; }
        //⦁	Email Address
        public string? SpouseEmail { get; set; }
        //⦁	Alcohol Requirement YES or NO
        public string? SpouseAlcohol { get; set; }
        //⦁	Food Preference VEG or NON VEG
        public string? SpouseFood { get; set; }
        //⦁	Dietary requirements
        public string? SpouseDietaryRequirements { get; set; }
        //⦁	T-shirt size
        public string? SpouseTshirtSize { get; set; }


        //Family Member Data
        //profilePic
        public IFormFile? FamilyMemberProfilePic { get; set; }
        public string? FamilyMemberFirstName { get; set; }
        //⦁	Middle Name
        public string? FamilyMemberMiddleName { get; set; }
        //⦁	Last Name
        public string? FamilyMemberLastName { get; set; }
        //⦁	Gender
        public string? FamilyMemberGender { get; set; }
        //⦁	Passport copy 
        public IFormFile? FamilyMemberPassportCopy { get; set; }
        //⦁	Passport Number
        public string? FamilyMemberPassportNumber { get; set; }
        //⦁	Issued Date of Passport
        public DateTimeOffset? FamilyMemberIssueDate { get; set; }
        //⦁	Expiry Date of Passport
        public DateTimeOffset? FamilyMemberExpiryDate { get; set; }
        //⦁	Date of Birth
        public DateTimeOffset? FamilyMemberDateOfBirth { get; set; }
        //⦁	Nationality
        public string? FamilyMemberNationality { get; set; }
        //⦁	Country of Residence
        public string? FamilyMemberCountryResidence { get; set; }
        //⦁	City of departure(travelling to Baku from which city?
        public string? FamilyMemberCityOfDeparture { get; set; }
        //⦁	Mobile Number
        public string? FamilyMemberMobileNumber { get; set; }
        //⦁	Email Address
        public string? FamilyMemberEmail { get; set; }
        //⦁	Alcohol Requirement YES or NO
        public string? FamilyMemberAlcohol { get; set; }
        //⦁	Food Preference VEG or NON VEG
        public string? FamilyMemberFood { get; set; }
        //⦁	Dietary requirements
        public string? FamilyMemberDietaryRequirements { get; set; }
        //⦁	T-shirt size
        public string? FamilyMemberTshirtSize { get; set; }
    }
}
