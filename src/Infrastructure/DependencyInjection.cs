﻿using Application.Common.Interfaces;
using Domain.Groups;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmartChargingDbContext>(options =>
                options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(SmartChargingDbContext).Assembly.FullName)));

            services.AddScoped<ISmartChargingDbContext>(provider => provider.GetService<SmartChargingDbContext>());

            services.AddScoped<IGroupRepository, GroupRepository>();

            return services;
        }
    }
}
