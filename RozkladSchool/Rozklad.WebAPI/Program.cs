﻿using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Infrastructure;
using Rozklad.Repository;
using Rozklad.Repository.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("RozkladSchoolConnection");
builder.Services.AddDbContext<RozkladContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CabinetAPIRepository>();
builder.Services.AddScoped<LessonAPIRepository>();
builder.Services.AddScoped<TeacherAPIRepository>();
builder.Services.AddScoped<DisciplineAPIRepository>();
builder.Services.AddScoped<ClassRoomAPIRepository>();
//builder.Services.AddScoped<TimetableAPIRepository>();
builder.Services.AddScoped<LessonAPIRepository>();
builder.Services.AddScoped<PupilAPIRepository>();
//builder.Services.AddScoped<UsersAPIRepository>();
builder.Services.AddScoped<WeekRepository>();




builder.Services.AddAutoMapper(typeof(AppAutoMapper).Assembly);

builder.Services.AddControllersWithViews();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {

        Version = "v1",
        Title = "Adding an API to our Schedule project",
        Description = "Education project with KN3, Ostroh Academy",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Email = "bohdan.laptiev@oa.edu.ua",
            Name = "Laptiev Bohdan"
        }

    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";//÷åðåç ³êñåìåëü êîìåíòàð³ äîêóìåíòóºòüñÿ êîä
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);


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

app.MapControllers();

app.MapFallbackToFile("index.html");