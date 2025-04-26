using ComputergyAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Computergy API",
        // Version = "v1",
        Description = "An API for managing an E-Commerce for computer-related resources for " +
        "Computergy store. This API provides endpoints for managing products, orders, customers, " +
        "and inventory. It is designed to be scalable, secure, and easy to integrate with third-party services.",
        TermsOfService = new Uri("https://Computergy.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Support Team",
            Email = "support@computergy.com",
            Url = new Uri("https://computergy.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Add XML comments if you're using them
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ComputergyDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-E4L6533\\SQLEXPRESS;Initial Catalog=ComputergyDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
