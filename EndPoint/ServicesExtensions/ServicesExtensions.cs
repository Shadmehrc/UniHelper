using System.Net;
using System.Reflection;
using System.Text;
using Application;
using Domain.Models;
using EndPoint.Options;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EndPoint.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwaggerApiVersion(this IServiceCollection services,
            IHostEnvironment environment)
        {
            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = ApiVersion.Default;
                option.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //if (environment.IsDevelopment())
            //{
            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.IncludeXmlComments(Path.Combine(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty,
                        XmlCommentsFileName));
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] { }
                            }
                    });
                }
                );
            //}
            return services;
        }

        public static IServiceCollection ConfigureSwagger(this WebApplicationBuilder builder, WebApplication webApplication, IApiVersionDescriptionProvider provider)
        {
            //if (!webApplication.Environment.IsDevelopment()) return builder.Services;
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            }
            );
            return builder.Services;
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", configurePolicy =>
                {
                    configurePolicy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenSettings = configuration.GetSection("JWtConfig").Get<TokenModel>();
            if (tokenSettings == null)
                throw new AbandonedMutexException("Token Model is NUll");
            else
                services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(configureOptions =>
                    {
                        configureOptions.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = tokenSettings.Issuer,
                            ValidAudience = tokenSettings.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key)),
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            RequireExpirationTime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                        configureOptions.SaveToken = true;
                    });
        }

        public static WebApplicationBuilder ConfigKestrel(this WebApplicationBuilder builder, int applicationPort)
        {
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.ConfigureHttpsDefaults(listenOptions =>
                {
                    serverOptions.Listen(IPAddress.Any, applicationPort, options =>
                    {
                        options.UseConnectionLogging();
                        options.Protocols = HttpProtocols.Http1AndHttp2;
                    });
                });
            });
            return builder;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddApplicationServices();
            services.AddInfrastructureServices();
        }

        private static string XmlCommentsFileName
        {
            get
            {
                var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return fileName;
            }
        }
    }
}