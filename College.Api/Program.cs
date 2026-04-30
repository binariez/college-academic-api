using College.Api.Persistence;
using College.Api.Repositories;
using College.Api.Repositories.Interfaces;
using College.Api.Services;
using College.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

// repo
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseClassRepository, CourseClassRepository>();
builder.Services.AddScoped<ICourseEnrollmentRepository, CourseEnrollmentRepository>();

// service
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseClassService, CourseClassService>();
builder.Services.AddScoped<ICourseEnrollmentService, CourseEnrollmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "MyCollege.Api V1");

    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
