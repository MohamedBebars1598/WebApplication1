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
                isSpouse = formDto.isSpouse,
                IssueDate = formDto.IssueDate,
                MiddleName = formDto.MiddleName,
                MobileNumber = formDto.MobileNumber,
                Nationality = formDto.Nationality,
                //PassportCopy = formDto.PassportCopy,
                PassportNumber = formDto.PassportNumber,
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
                //SpousePassportCopy = formDto.SpousePassportCopy,
                SpousePassportNumber = formDto.SpousePassportNumber,
                SpouseTshirtSize = formDto.SpouseTshirtSize,
                TshirtSize = formDto.TshirtSize,
            };

            using (var ms = new MemoryStream())
            {
                //save images
                if (formDto.PassportCopy != null)
                {

                    ms.Position = 0;
                    ms.SetLength(0);
                    formDto.PassportCopy.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    data.PassportCopy = fileBytes;
                }

                if (formDto.SpousePassportCopy != null)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    formDto.SpousePassportCopy.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    data.SpousePassportCopy = fileBytes;
                }
            }

            _context.Forms.Add(data);
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
                worksheet.Cell(1, 14).Value = "Alcohol Requirement";
                worksheet.Cell(1, 15).Value = "Food Preference";
                worksheet.Cell(1, 16).Value = "Dietary Requirements";
                worksheet.Cell(1, 17).Value = "T-shirt size";
                worksheet.Cell(1, 18).Value = "Spouse – yes or no";
                worksheet.Cell(1, 19).Value = "Spouse First Name";
                worksheet.Cell(1, 20).Value = "Spouse Middle Name";
                worksheet.Cell(1, 21).Value = "Spouse Last Name";
                worksheet.Cell(1, 22).Value = "Spouse Gender";
                worksheet.Cell(1, 23).Value = "Spouse Passport Number";
                worksheet.Cell(1, 24).Value = "Spouse Issue Date of Passport";
                worksheet.Cell(1, 25).Value = "Spouse Expiry Date of Passport";
                worksheet.Cell(1, 26).Value = "Spouse Date of Birth";
                worksheet.Cell(1, 27).Value = "Spouse Nationality";
                worksheet.Cell(1, 28).Value = "Spouse Country of Residence";
                worksheet.Cell(1, 29).Value = "Spouse City of Departure";
                worksheet.Cell(1, 30).Value = "Spouse Mobile Number";
                worksheet.Cell(1, 31).Value = "Spouse Email Address";
                worksheet.Cell(1, 32).Value = "Spouse Alcohol Requirement";
                worksheet.Cell(1, 33).Value = "Spouse Food Preference";
                worksheet.Cell(1, 34).Value = "Spouse Dietary Requirements";
                worksheet.Cell(1, 35).Value = "Spouse T-shirt size";
                worksheet.Cell(1, 36).Value = "Link";
                worksheet.Cell(1, 37).Value = "Spouse Link";
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
                    worksheet.Cell(row, 6).Value = entity.IssueDate.ToString("yyyy-MM-dd");
                    worksheet.Cell(row, 7).Value = entity.ExpiryDate.ToString("yyyy-MM-dd");
                    worksheet.Cell(row, 8).Value = entity.DateOfBirth.ToString("yyyy-MM-dd");
                    worksheet.Cell(row, 9).Value = entity.Nationality;
                    worksheet.Cell(row, 10).Value = entity.CountryResidence;
                    worksheet.Cell(row, 11).Value = entity.CityOfDeparture;
                    worksheet.Cell(row, 12).Value = entity.MobileNumber;
                    worksheet.Cell(row, 13).Value = entity.Email;
                    worksheet.Cell(row, 14).Value = entity.Alcohol;
                    worksheet.Cell(row, 15).Value = entity.Food;
                    worksheet.Cell(row, 16).Value = entity.DietaryRequirements;
                    worksheet.Cell(row, 17).Value = entity.TshirtSize;
                    worksheet.Cell(row, 18).Value = entity.isSpouse ? "Yes" : "No";

                    if (entity.isSpouse)
                    {
                        // Set cell values for spouse info if it exists
                        worksheet.Cell(row, 19).Value = entity.SpouseFirstName;
                        worksheet.Cell(row, 20).Value = entity.SpouseMiddleName;
                        worksheet.Cell(row, 21).Value = entity.SpouseLastName;
                        worksheet.Cell(row, 22).Value = entity.SpouseGender;
                        worksheet.Cell(row, 23).Value = entity.SpousePassportNumber;
                        worksheet.Cell(row, 24).Value = entity.SpouseIssueDate?.ToString("yyyy-MM-dd");
                        worksheet.Cell(row, 25).Value = entity.SpouseExpiryDate?.ToString("yyyy-MM-dd");
                        worksheet.Cell(row, 26).Value = entity.SpouseDateOfBirth?.ToString("yyyy-MM-dd");
                        worksheet.Cell(row, 27).Value = entity.SpouseNationality;
                        worksheet.Cell(row, 28).Value = entity.SpouseCountryResidence;
                        worksheet.Cell(row, 29).Value = entity.SpouseCityOfDeparture;
                        worksheet.Cell(row, 30).Value = entity.SpouseMobileNumber;
                        worksheet.Cell(row, 31).Value = entity.SpouseEmail;
                        worksheet.Cell(row, 32).Value = entity.SpouseAlcohol;
                        worksheet.Cell(row, 33).Value = entity.SpouseFood;
                        worksheet.Cell(row, 34).Value = entity.SpouseDietaryRequirements;
                        worksheet.Cell(row, 35).Value = entity.SpouseTshirtSize;
                        worksheet.Cell(row, 36).Value = "DownloadImage";
                        worksheet.Cell(row, 37).Value =entity.SpousePassportCopy==null?"N/A":"DownloadImage";
                    }

                    // Create hyperlink to Passport Copy image if available
                    if (entity.PassportCopy != null)
                    {

                        string host = HttpContext.Request.Host.ToString() + '/';

                        if (!host.StartsWith("localhost:"))
                        {
                            host = _configuration["Root:BaseRoot"];

                        }
                        worksheet.Cell(row, 36).SetHyperlink(new XLHyperlink($"https://{host}api/Form/DownloadImage?id={entity.Id}&isFirst=true"));
                    }

                    if (entity.SpousePassportCopy != null)
                    {

                        string host = HttpContext.Request.Host.ToString() + '/';

                        if (!host.StartsWith("localhost:"))
                        {
                            host = _configuration["Root:BaseRoot"];

                        }
                        worksheet.Cell(row, 37).SetHyperlink(new XLHyperlink($"https://{host}api/Form/DownloadImage?id={entity.Id}&&isFirst=false"));
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
        public async Task<IActionResult> DownloadImage([FromQuery]int id, [FromQuery]bool isFirst)
        {
            var data = await _context.Forms.FirstAsync(f => f.Id == id);
            if (data == null) {

                return NotFound();
            }
            byte[] imageBytes = new byte[] { };
            if (isFirst)
            {

                imageBytes = data.PassportCopy;
               

            }
            else
            {
                imageBytes = data.SpousePassportCopy??new byte[] { };

            }
            string contentType = "image/jpeg"; // Update this with the appropriate content type for your image
            string fileName = "image.jpg"; // Update this with the desired filename for the downloaded image

            // Return the image as a file attachment
            return File(imageBytes, contentType, fileName);
        }

    }
}
