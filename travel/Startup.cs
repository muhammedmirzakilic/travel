using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using travel.Data;
using travel.DTO;
using travel.Interfaces;
using travel.Services;

namespace travel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "travel", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "travel v1"));
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            AddDummyData(services);
        }

        public void AddDummyData(IServiceProvider services)
        {
            var passengerService = services.GetService<IPassengerService>();
            var dummyPassengers = new List<Passenger>();
            dummyPassengers.Add(new Passenger()
            {
                DocumentNo = "1",
                DocumentType = Enums.DocumentType.Passport,
                Gender = true,
                IssueDate = DateTime.UtcNow,
                Name = "Muhammed",
                Surname = "Kilic"
            });

            dummyPassengers.Add(new Passenger()
            {
                DocumentNo = "2",
                DocumentType = Enums.DocumentType.Passport,
                Gender = true,
                IssueDate = DateTime.UtcNow,
                Name = "Mirza",
                Surname = "Kilic"
            });

            dummyPassengers.Add(new Passenger()
            {
                DocumentNo = "2",
                DocumentType = Enums.DocumentType.Passport,
                Gender = true,
                IssueDate = DateTime.UtcNow,
                Name = "Muhammed Mirza",
                Surname = "Kilic"
            });
            var random = new Random();
            foreach (var passenger in dummyPassengers)
            {
                var source = random.Next(10) % 2 == 0 ?
                    Enums.Source.Offline : Enums.Source.Online;
                passengerService.Create(source, passenger);
            }
        }
    }
}
