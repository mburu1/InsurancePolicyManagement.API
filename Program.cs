using InsurancePolicyManagement.API.Domain.Interfaces;
using InsurancePolicyManagement.API.Domain.Services;
using InsurancePolicyManagement.API.Infrastructure.Data;
using InsurancePolicyManagement.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<InsuranceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "InsurancePolicyManagement",
        Description = "InsurancePolicyManagement Api",
        TermsOfService = new Uri("https://www.abc.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Antony Mburu",
            Email = "amburu415@gmail.com",
            Url = new Uri("https://www.abc.com/"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under OpenApiLicense",
            Url = new Uri("https://www.abc.com/license"),
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
