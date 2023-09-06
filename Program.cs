using CheckValidate.App.DomainAllowed.Service;
using CheckValidate.App.LoudSpeaker.Model;
using CheckValidate.Base.FileService;
using CheckValidate.Base.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
var urlAllowed = configuration["pathFileDomain"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<RequestModelApi1>, RequestModelApi1Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi2>, RequestModelApi2Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi3>, RequestModelApi3Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi4>, RequestModelApi4Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi5>, RequestModelApi5Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi6>, RequestModelApi6Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi7>, RequestModelApi7Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi8>, RequestModelApi8Validator>();
builder.Services.AddTransient<IValidator<RequestModelApi9>, RequestModelApi9Validator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IDomainAllowedService, DomainAllowedService>();
builder.Services.AddTransient<IFileService, FileService>();

var myArray = builder.Services.BuildServiceProvider().GetService<IDomainAllowedService>()!.GetList().Result;
if (myArray == null)
    myArray = new string[]{};

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins", b =>
    {
        b.WithOrigins(myArray)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
