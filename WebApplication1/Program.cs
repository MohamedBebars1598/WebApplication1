using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase;

var builder = WebApplication.CreateBuilder(args);

//var allowedOrigins = builder.Configuration.GetSection("Origins").GetChildren().Select(r => r.Value).ToArray();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
       builder =>
       {
           builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
       });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});
var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    // Here is the migration executed
    appDbContext.Database.Migrate();
}

app.Run();
