using DccMeter.Api.Domain.Interfaces;
using DccMeter.Repository.SQLServer;
using DccMeter.Repository.SQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
//using Euronet.Audit.Serilog;
using Euronet.Api.Helpers;
using Euronet.Audit.Serilog;
using Microsoft.Extensions.DependencyInjection;
using Euronet.Audit.Settings;
using Euronet.Audit;
using Dtc.AccessSight.Web.Mvc.ModelBinders;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using DccMeter.API.Settings;
using NSwag.AspNetCore;
using System.Text.Json.Serialization;
//using NSwag.SwaggerGeneration.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration app_settings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

Settings.Initialize(app_settings);

#region Audit


if (Settings.Instance.AuditSettings.DisableAudit == false)
{
    Log.Information("Configuring Audit Log...");

    string auditConnectionString = Settings.Instance.AuditSettings.ConnectionString;

    GlobalEnrichOptions globalEnrichOptions = new GlobalEnrichOptions()
    {
        ApplicationId = Convert.ToInt16(builder.Configuration["AppSettings:ApplicationId"]),
        ApplicationName = EnvironmentHelper.ApplicationName,
        ApplicationVersion = EnvironmentHelper.Version
    };

    AuditDbSettings settings = new AuditDbSettings()
    {
        ConnectionString = auditConnectionString, //builder.Configuration["AuditSettings:ConnectionString"],
        DisableAudit = Settings.Instance.AuditSettings.DisableAudit, //Convert.ToBoolean(builder.Configuration["AuditSettings:DisableAudit"]),
        SchemaName = Settings.Instance.AuditSettings.SchemaName, //builder.Configuration["AuditSettings:SchemaName"],
        Severity = Settings.Instance.AuditSettings.Severity,//  builder.Configuration["AuditSettings:Severity"],
        TableName = Settings.Instance.AuditSettings.TableName //builder.Configuration["AuditSettings:TableName"]
    };

    builder.Services.AddSqlServerSerilogAudit(settings, globalEnrichOptions);

}

#endregion

#region Mvc

builder.Services.AddMvc(config =>
{
    //config.EnableEndpointRouting = false;

    config.Filters.Add(typeof(AuditLogFilterAttribute));
    config.EnableEndpointRouting = false;

    //TODO
    //if (AppSettings.Instance.AuthorizationSettings.DisableAuthorization)
    //{
    //config.Filters.Add(new AllowAnonymousFilter());
    //}
});

#endregion


//builder.Services.AddDbContext<DccMeterContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddDccMeterSqlServerRepository(opt => opt.UseSqlServer(Settings.Instance.AppSettings.ConnectionString)); //(builder.Configuration["AppSettings:ConnectionString"]));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    // Add custom JsonConverter for enums to serialize as strings
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 

//builder.Services.AddMvc(config => config.Filters.Add(typeof(object)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.UseStaticFiles();

app.UseMvcWithDefaultRoute();


app.Run();
