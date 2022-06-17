using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TesteVolvo.Application.Interfaces;
using TesteVolvo.Application.Mappings;
using TesteVolvo.Application.Services;
using TesteVolvo.Domain.Interfaces;
using TesteVolvo.Infra.Data.Context;
using TesteVolvo.Infra.Data.Repositories;

namespace TesteVolvo.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("TesteVolvo.Application");
            services.AddMediatR(myHandlers);

            return services;


        }
    }
}
