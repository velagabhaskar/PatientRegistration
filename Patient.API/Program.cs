using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientInfo.API;
using PatientInfo.API.DTO;
using PatientInfo.DAL;
using PatientInfo.DAL.Logger;
using System.Web.Http.Cors;


using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientDataContext>(db => {
    db.UseSqlServer(builder.Configuration.GetConnectionString("SqlDBConenction"));
       db.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

}, ServiceLifetime.Singleton);

//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddSingleton(typeof(IRepository<PatientInfo. DAL.Models.Patient>), typeof(Repository<PatientInfo.DAL.Models.Patient>));

builder.Services.AddSingleton<IPatientRepository, PatientRepository>() ;

builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
// default, no below code
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF_API v1"));
}
// add below code, when start with https://..../swagger
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);
// Configure the HTTP request pipeline.
var cors = new EnableCorsAttribute("www.example.com", "*", "*");
app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging();

app.UseRouting();
app.UseCors(
    options =>
  {
      options.WithOrigins("*")     
      .AllowAnyHeader()
      .AllowAnyMethod();
  }
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
