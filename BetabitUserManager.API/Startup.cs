using System;
using System.IO;
using System.Reflection;
using BetabitUserManager.API.Config;
using BetabitUserManager.Infrastructure;
using BetabitUserManager.UseCases;
using BetabitUserManager.UseCases.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BetabitUserManager.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("CQRS_SAMPLE");
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddMediatR(typeof(IUnitOfWork).Assembly);

        services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
            });

        services.AddSwaggerGen(cfg =>
        {
            //cfg.SwaggerDoc("v1", new Info
            //{
            //    Title = "CQRS with MediatR - Example API",
            //    Version = "v1",
            //    Description = "Simple API built to demonstrate how to use CQRS with MediatR in ASP.NET Core applications.",
            //    Contact = new Contact
            //    {
            //        Name = "Evandro Gayer Gomes",
            //        Url = "https://github.com/evgomes",
            //    },
            //    License = new License
            //    {
            //        Name = "MIT",
            //    },
            //});

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //cfg.IncludeXmlComments(xmlPath);
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        //app.UseHsts();


        app.UseRouting();
        //app.UseHttpsRedirection();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS with MediatR - Example API v1");
        });
    }
}