using EndPoint.Filters;
using EndPoint.ServicesExtensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

var generalConfigs = GeneralConfigsSetting.GetGeneralSettings(config);

builder.WebHost.UseUrls(generalConfigs.Url);

builder.ConfigKestrel(generalConfigs.Port);

builder.Services.AddControllers(option => { option.Filters.Add<ApiExceptionFilterAttribute>(); })
    .AddJsonOptions(option => option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerApiVersion(builder.Environment);

builder.Services.ConfigureCors();

builder.Services.AddJwtAuthorization(config);

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

builder.ConfigureSwagger(app, provider);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();