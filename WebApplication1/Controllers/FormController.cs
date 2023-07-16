using Azure;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase;
using WebApplication1.DataBase.Entities;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public FormController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("submit")]
        public async Task<IActionResult> Post([FromForm] FormDto formDto)
        {
            var data = new FormEntity()
            {
                Alcohol = formDto.Alcohol,
                CityOfDeparture = formDto.CityOfDeparture,
                CountryResidence = formDto.CountryResidence,
                DateOfBirth = formDto.DateOfBirth,
                DietaryRequirements = formDto.DietaryRequirements,
                Email = formDto.Email,
                FirstName = formDto.FirstName,
                LastName = formDto.LastName,
                ExpiryDate = formDto.ExpiryDate,
                Food = formDto.Food,
                Gender = formDto.Gender,
                Type = formDto.Type,
                IssueDate = formDto.IssueDate,
                MiddleName = formDto.MiddleName,
                MobileNumber = formDto.MobileNumber,
                Nationality = formDto.Nationality,
                PassportNumber = formDto.PassportNumber,
                //spouse
                SpouseAlcohol = formDto.SpouseAlcohol,
                SpouseCityOfDeparture = formDto.SpouseCityOfDeparture,
                SpouseCountryResidence = formDto.SpouseCountryResidence,
                SpouseDateOfBirth = formDto.SpouseDateOfBirth,
                SpouseDietaryRequirements = formDto.SpouseDietaryRequirements,
                SpouseEmail = formDto.SpouseEmail,
                SpouseExpiryDate = formDto.SpouseExpiryDate,
                SpouseFirstName = formDto.SpouseFirstName,
                SpouseFood = formDto.SpouseFood,
                SpouseGender = formDto.SpouseGender,
                SpouseIssueDate = formDto.SpouseIssueDate,
                SpouseLastName = formDto.SpouseLastName,
                SpouseMiddleName = formDto.SpouseMiddleName,
                SpouseMobileNumber = formDto.SpouseMobileNumber,
                SpouseNationality = formDto.SpouseNationality,
                SpousePassportNumber = formDto.SpousePassportNumber,
                SpouseTshirtSize = formDto.SpouseTshirtSize,
                TshirtSize = formDto.TshirtSize,
                //family
                FamilyMemberAlcohol = formDto.FamilyMemberAlcohol,
                FamilyMemberCityOfDeparture=formDto.FamilyMemberCityOfDeparture,
                FamilyMemberCountryResidence = formDto.FamilyMemberCountryResidence,
                FamilyMemberDateOfBirth = formDto.FamilyMemberDateOfBirth,
                FamilyMemberDietaryRequirements = formDto.FamilyMemberDietaryRequirements,
                FamilyMemberEmail = formDto.FamilyMemberEmail,
                FamilyMemberExpiryDate = formDto.FamilyMemberExpiryDate,
                FamilyMemberFirstName = formDto.FamilyMemberFirstName,
                FamilyMemberFood = formDto.FamilyMemberFood,
                FamilyMemberGender = formDto.FamilyMemberGender,
                FamilyMemberIssueDate = formDto.FamilyMemberIssueDate,
                FamilyMemberLastName = formDto.FamilyMemberLastName,
                FamilyMemberMiddleName = formDto.FamilyMemberMiddleName,
                FamilyMemberMobileNumber = formDto.FamilyMemberMobileNumber,
                FamilyMemberNationality = formDto.FamilyMemberNationality,
                FamilyMemberPassportNumber = formDto.FamilyMemberPassportNumber,
                FamilyMemberTshirtSize = formDto.FamilyMemberTshirtSize,
                
                


            };

            using (var ms = new MemoryStream())
            {
                //user data
                ms.Position = 0;
                ms.SetLength(0);
                formDto.PassportCopy.CopyTo(ms);
                var fileBytes = ms.ToArray();
                data.PassportCopy = fileBytes;
                ms.Position = 0;
                ms.SetLength(0);
                formDto.UserProfilePic.CopyTo(ms);
                fileBytes = ms.ToArray();
                data.UserProfilePic = fileBytes;
                switch (formDto.Type)
                {

                        case FormTypecs.Spouse:
                        if (formDto.SpousePassportCopy != null)
                        {
                            ms.Position = 0;
                            ms.SetLength(0);
                            formDto.SpousePassportCopy.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            data.SpousePassportCopy = fileBytes;
                        }
                        if (formDto.SpouseProfilePic != null)
                        {
                            //spouse profile pic
                            ms.Position = 0;
                            ms.SetLength(0);
                            formDto.SpouseProfilePic.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            data.SpouseProfilePic = fileBytes;
                        }
                        else
                        {
                            return BadRequest("Spouse Profile Pic Cannot be null");
                        }
                        break;

                    case FormTypecs.Family:
                        if (formDto.FamilyMemberPassportCopy != null)
                        {
                            ms.Position = 0;
                            ms.SetLength(0);
                            formDto.FamilyMemberPassportCopy.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            data.FamilyMemberPassportCopy = fileBytes;
                        }
                        if (formDto.FamilyMemberProfilePic != null)
                        {
                            //family profile pic
                            ms.Position = 0;
                            ms.SetLength(0);
                            formDto.FamilyMemberProfilePic.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            data.FamilyMemberProfilePic = fileBytes;
                        }
                        else
                        {
                            return BadRequest("Family Member Profile Pic Cannot be null");
                        }
                        break;

                }
                
            }

            _context.Forms.Add(data);
            _context.Users.Add(new UserEntity()
            {
                Email = data.Email,
            });
            await _context.SaveChangesAsync();

            return Ok("Success");
        }

        [HttpGet]
        [Route("DownloadExcel")]
        public IActionResult DownloadExcel()
        {
            // Get the data from your database using Entity Framework Core
            List<FormEntity> formEntities = _context.Forms.ToList();
            // Retrieve the data from the database

            // Create a new Excel workbook
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FormEntities");
                // Set the headers
                worksheet.Cell(1, 1).Value = "First Name";
                worksheet.Cell(1, 2).Value = "Middle Name";
                worksheet.Cell(1, 3).Value = "Last Name";
                worksheet.Cell(1, 4).Value = "Gender";
                worksheet.Cell(1, 5).Value = "Passport Number";
                worksheet.Cell(1, 6).Value = "Issue Date of Passport";
                worksheet.Cell(1, 7).Value = "Expiry Date of Passport";
                worksheet.Cell(1, 8).Value = "Date of Birth";
                worksheet.Cell(1, 9).Value = "Nationality";
                worksheet.Cell(1, 10).Value = "Country of Residence";
                worksheet.Cell(1, 11).Value = "City of Departure";
                worksheet.Cell(1, 12).Value = "Mobile Number";
                worksheet.Cell(1, 13).Value = "Email Address";
                worksheet.Cell(1, 14).Value = "Alcohol";
                worksheet.Cell(1, 15).Value = "Food Preference";
                worksheet.Cell(1, 16).Value = "Dietary Requirements";
                worksheet.Cell(1, 17).Value = "T-shirt size";
                //Accompanied
                worksheet.Cell(1, 18).Value = "Accompanied Person";
                worksheet.Cell(1, 19).Value = "Accompanied First Name";
                worksheet.Cell(1, 20).Value = "Accompanied Middle Name";
                worksheet.Cell(1, 21).Value = "Accompanied Last Name";
                worksheet.Cell(1, 22).Value = "AccompaniedGender";
                worksheet.Cell(1, 23).Value = "Accompanied Passport Number";
                worksheet.Cell(1, 24).Value = "Accompanied Issue Date of Passport";
                worksheet.Cell(1, 25).Value = "Accompanied Expiry Date of Passport";
                worksheet.Cell(1, 26).Value = "Accompanied Date of Birth";
                worksheet.Cell(1, 27).Value = "Accompanied Nationality";
                worksheet.Cell(1, 28).Value = "Accompanied Country of Residence";
                worksheet.Cell(1, 29).Value = "Accompanied City of Departure";
                worksheet.Cell(1, 30).Value = "Accompanied Mobile Number";
                worksheet.Cell(1, 31).Value = "Accompanied Email Address";
                worksheet.Cell(1, 32).Value = "Accompanied Alcohol Requirement";
                worksheet.Cell(1, 33).Value = "Accompanied Food Preference";
                worksheet.Cell(1, 34).Value = "Accompanied Dietary Requirements";
                worksheet.Cell(1, 35).Value = "Accompanied T-shirt size";
                worksheet.Cell(1, 36).Value = "Passport Copy";
                worksheet.Cell(1, 37).Value = "Accompanied Passport Copy Link";
                worksheet.Cell(1, 38).Value = "Profile Picture Link";
                worksheet.Cell(1, 39).Value = "Accompanied Profile Picture Link";
                // Add other headers for the remaining properties

                // Populate the data
                for (int i = 0; i < formEntities.Count; i++)
                {
                    var entity = formEntities[i];
                    int row = i + 2;

                    worksheet.Cell(row, 1).Value = entity.FirstName;
                    worksheet.Cell(row, 2).Value = entity.MiddleName;
                    worksheet.Cell(row, 3).Value = entity.LastName;
                    // Set cell values for the remaining properties
                    worksheet.Cell(row, 4).Value = entity.Gender;
                    worksheet.Cell(row, 5).Value = entity.PassportNumber;
                    worksheet.Cell(row, 6).Value = entity.IssueDate.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 7).Value = entity.ExpiryDate.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 8).Value = entity.DateOfBirth.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 9).Value = entity.Nationality;
                    worksheet.Cell(row, 10).Value = entity.CountryResidence;
                    worksheet.Cell(row, 11).Value = entity.CityOfDeparture;
                    worksheet.Cell(row, 12).Value = entity.MobileNumber;
                    worksheet.Cell(row, 13).Value = entity.Email;
                    worksheet.Cell(row, 14).Value = entity.Alcohol;
                    worksheet.Cell(row, 15).Value = entity.Food;
                    worksheet.Cell(row, 16).Value = entity.DietaryRequirements;
                    worksheet.Cell(row, 17).Value = entity.TshirtSize;
                    worksheet.Cell(row, 18).Value = entity.Type switch
                    {
                        FormTypecs.Classic => "none",
                        FormTypecs.Family => "Family Member",
                        FormTypecs.Spouse => "Spouse",
                        _ => "none",
                    };
                    worksheet.Cell(row, 36).Value = "DownloadImage";
                    worksheet.Cell(row, 38).Value = "DownloadImage";
                    // Create hyperlink to Passport Copy image if available
                    if (entity.PassportCopy != null)
                    {

                        string host = HttpContext.Request.Host.ToString() + '/';

                        if (!host.StartsWith("localhost:"))
                        {
                            host = _configuration["Root:BaseRoot"];

                        }
                        worksheet.Cell(row, 36).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&imageType=1"));
                        worksheet.Cell(row, 38).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&imageType=1.1"));
                    }
                    switch (entity.Type)
                    {

                        case FormTypecs.Spouse:
                            // Set cell values for spouse info if it exists
                            worksheet.Cell(row, 19).Value = entity.SpouseFirstName;
                            worksheet.Cell(row, 20).Value = entity.SpouseMiddleName??"none";
                            worksheet.Cell(row, 21).Value = entity.SpouseLastName;
                            worksheet.Cell(row, 22).Value = entity.SpouseGender;
                            worksheet.Cell(row, 23).Value = entity.SpousePassportNumber;
                            worksheet.Cell(row, 24).Value = entity.SpouseIssueDate?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 25).Value = entity.SpouseExpiryDate?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 26).Value = entity.SpouseDateOfBirth?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 27).Value = entity.SpouseNationality;
                            worksheet.Cell(row, 28).Value = entity.SpouseCountryResidence;
                            worksheet.Cell(row, 29).Value = entity.SpouseCityOfDeparture;
                            worksheet.Cell(row, 30).Value = entity.SpouseMobileNumber;
                            worksheet.Cell(row, 31).Value = entity.SpouseEmail;
                            worksheet.Cell(row, 32).Value = entity.SpouseAlcohol;
                            worksheet.Cell(row, 33).Value = entity.SpouseFood;
                            worksheet.Cell(row, 34).Value = entity.SpouseDietaryRequirements;
                            worksheet.Cell(row, 35).Value = entity.SpouseTshirtSize;
                            worksheet.Cell(row, 37).Value = entity.SpousePassportCopy == null ? "none" : "DownloadImage";
                            worksheet.Cell(row, 39).Value = entity.SpousePassportCopy == null ? "none" : "DownloadImage";
                            if (entity.SpousePassportCopy != null)
                            {
                                string host = HttpContext.Request.Host.ToString() + '/';

                                if (!host.StartsWith("localhost:"))
                                {
                                    host = _configuration["Root:BaseRoot"];

                                }
                                worksheet.Cell(row, 37).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&&imageType=2"));
                            }
                            if (entity.SpouseProfilePic != null)
                            {
                                string host = HttpContext.Request.Host.ToString() + '/';

                                if (!host.StartsWith("localhost:"))
                                {
                                    host = _configuration["Root:BaseRoot"];

                                }
                                worksheet.Cell(row, 39).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&&imageType=2.1"));
                            }
                            break;

                        case FormTypecs.Family:
                            worksheet.Cell(row, 19).Value = entity.FamilyMemberFirstName;
                            worksheet.Cell(row, 20).Value = entity.FamilyMemberMiddleName ?? "none";
                            worksheet.Cell(row, 21).Value = entity.FamilyMemberLastName;
                            worksheet.Cell(row, 22).Value = entity.FamilyMemberGender;
                            worksheet.Cell(row, 23).Value = entity.FamilyMemberPassportNumber;
                            worksheet.Cell(row, 24).Value = entity.FamilyMemberIssueDate?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 25).Value = entity.FamilyMemberExpiryDate?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 26).Value = entity.FamilyMemberDateOfBirth?.ToString("dd-MM-yyyy");
                            worksheet.Cell(row, 27).Value = entity.FamilyMemberNationality;
                            worksheet.Cell(row, 28).Value = entity.FamilyMemberCountryResidence;
                            worksheet.Cell(row, 29).Value = entity.FamilyMemberCityOfDeparture;
                            worksheet.Cell(row, 30).Value = entity.FamilyMemberMobileNumber;
                            worksheet.Cell(row, 31).Value = entity.FamilyMemberEmail;
                            worksheet.Cell(row, 32).Value = entity.FamilyMemberAlcohol;
                            worksheet.Cell(row, 33).Value = entity.FamilyMemberFood;
                            worksheet.Cell(row, 34).Value = entity.FamilyMemberDietaryRequirements;
                            worksheet.Cell(row, 35).Value = entity.FamilyMemberTshirtSize;
                            worksheet.Cell(row, 37).Value = entity.FamilyMemberPassportCopy == null ? "none" : "DownloadImage";
                            worksheet.Cell(row, 39).Value = entity.FamilyMemberProfilePic == null ? "none" : "DownloadImage";

                            if (entity.FamilyMemberPassportCopy != null)
                            {

                                string host = HttpContext.Request.Host.ToString() + '/';

                                if (!host.StartsWith("localhost:"))
                                {
                                    host = _configuration["Root:BaseRoot"];

                                }
                                worksheet.Cell(row, 37).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&&imageType=3"));
                            }
                            if (entity.FamilyMemberProfilePic != null)
                            {
                                string host = HttpContext.Request.Host.ToString() + '/';

                                if (!host.StartsWith("localhost:"))
                                {
                                    host = _configuration["Root:BaseRoot"];

                                }
                                worksheet.Cell(row, 39).SetHyperlink(new XLHyperlink($"http://{host}api/Form/DownloadImage?id={entity.Id}&&imageType=3.1"));
                            }
                            break;
                    }
                }

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                // Convert the workbook to a byte array
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var fileBytes = stream.ToArray();

                    // Return the Excel file as a downloadable attachment
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "FormEntities.xlsx");
                }
            }
        }


        [HttpGet]
        [Route("DownloadImage")]
        public async Task<IActionResult> DownloadImage([FromQuery] int id, [FromQuery] double imageType)
        {
            var data = await _context.Forms.FirstAsync(f => f.Id == id);
            if (data == null)
            {

                return NotFound();
            }
            byte[] imageBytes = new byte[] { };
            if (imageType==1)
            {

                imageBytes = data.PassportCopy;


            }else if (imageType == 1.1)
            {
                imageBytes = data.UserProfilePic;
            }
            else if (imageType == 2)
            {
                imageBytes = data.SpousePassportCopy ?? new byte[] { };
            }else if (imageType==2.1)
            {
                imageBytes = data.SpouseProfilePic ?? new byte[] { };
            }
            else if (imageType==3)
            {
                imageBytes = data.FamilyMemberPassportCopy ?? new byte[] { };

            }else if (imageType == 3.1)
            {
                imageBytes = data.FamilyMemberProfilePic ?? new byte[] { };
            }
            string contentType = "image/jpeg"; // Update this with the appropriate content type for your image
            string fileName = "image.jpg"; // Update this with the desired filename for the downloaded image

            // Return the image as a file attachment
            return File(imageBytes, contentType, fileName);
        }


        [HttpGet]
        [Route("CheckEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var isExist = await _context.Forms.AnyAsync(f => f.Email == email);
            if (isExist)
                return Ok();

            return BadRequest("Email not Exist");
        }

    }
}
