using FormulaOne.DataServices.Data;
using FormulaOne.DataServices.Repositories;
using FormulaOne.DataServices.Repositories.Interfaces;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var HangFireConnection = builder.Configuration.GetConnectionString("HangFire");
builder.Services.AddDbContext<AppDbContext>(options => 
{
    var conexion = builder.Configuration.GetConnectionString("local");

    options.UseSqlServer(conexion);



});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IAchievementRepository, AchievementRepository>();
builder.Services.AddScoped <IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddHangfire(confi=>
confi.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(HangFireConnection));



builder.Services.AddHangfireServer();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();

app.MapHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate(() => Console.WriteLine("hello from hangifre"), "* * * * *");

app.Run();
