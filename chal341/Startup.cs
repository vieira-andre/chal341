using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using chal341.Filters;
using chal341.Helpers;
using chal341.Mappers;
using chal341.Repositories;
using chal341.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace chal341
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services
                .AddMvc(options => { options.Filters.Add<ValidationFilter>(); })
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c => 
            { 
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Chal341 API", Version = "v1", Contact = new OpenApiContact { Name = "André Vieira" },
                    Description = "[PoC] A serverless API for a financial institution, providing capability in managing currency-related operations."
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<ICurrencyOpsService, CurrencyOpsService>();
            services.AddScoped<ISegmentOpsService, SegmentOpsService>();
            services.AddScoped<IExchangeFeeRepository, ExchangeFeeRepository>();

            services.AddAWSService<IAmazonDynamoDB>(ServiceLifetime.Scoped);
            services.AddDefaultAWSOptions(new AWSOptions 
            { 
                Region = RegionEndpoint.GetBySystemName(Environment.GetEnvironmentVariable("AWS_REGION")) 
            });

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Prod/swagger/v1/swagger.json", "Chal341 API"); // remove '/Prod' when running locally
            });
        }
    }
}
