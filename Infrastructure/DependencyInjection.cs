using System;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IHostEnvironment environment,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("InsuranceConnection");

            services
                .AddDbContext<FestivalsDbContext>(options =>
                {
                    options.UseMySql(connectionString,
                        mySqlOptionsAction: mySqlOptions =>
                        {
                            mySqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 10,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                null);          
                        });
                });
            
            services.AddScoped<IFestivalDbContext>(provider => provider.GetService<FestivalsDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = configuration["Jwt:Authority"];
                o.Audience = configuration["Jwt:Audience"];
                o.RequireHttpsMetadata = false;
            });

            return services;
        }
    }
}