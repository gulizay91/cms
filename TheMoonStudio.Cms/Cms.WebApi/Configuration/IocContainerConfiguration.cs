using AutoMapper;
using Cms.Mapping;
using Cms.Repository.Configuration;
using Cms.Repository.EntityFramework;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service;
using Cms.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.WebApi.Configuration
{
  public static class IocContainerConfiguration
  {
    /// <summary>
    /// Configures the service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      // multitenancy one db
      var connection = configuration["ConnectionStrings"];

      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseSqlServer(configuration.GetConnectionString("DefaultMsSqlConnection"));
      });

      // multitenancy seperate db
      /*
      services.AddDbContext<AppDbContext>((serviceProvider, options) =>
      {
        var multitenant = configuration.GetSection("MultiTenancy").Get<MultiTenancy>();

        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        var httpRequest = httpContext.Request;

        var hostName = httpRequest.Host.Value.ToLower();
        var tenant = multitenant.GetTenantByHost(hostName);

        var dbConnectionString = tenant.ConnectionString;

        options.UseSqlServer(dbConnectionString);
      });
      */
      services.AddEntityFrameworkSqlServer();
      services.AddScoped<AppDbContext>();

      //eklenen servicelerin kullanılabilmesi için dependecny injection için kullanılır
      services.AddScoped<ITenantService, TenantService>();
      services.AddScoped<ITenantRepository, TenantRepository>();
      services.AddScoped<ICompanyService, CompanyService>();
      services.AddScoped<ICompanyRepository, CompanyRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserTypeService, UserTypeService>();
      services.AddScoped<IUserTypeRepository, UserTypeRepository>();
      services.AddScoped<ICrewService, CrewService>();
      services.AddScoped<ICrewRepository, CrewRepository>();
      services.AddScoped<IBoatService, BoatService>();
      services.AddScoped<IBoatRepository, BoatRepository>();
      services.AddScoped<IBoatCrewService, BoatCrewService>();
      services.AddScoped<IBoatCrewRepository, BoatCrewRepository>();
      services.AddScoped<IMarinaService, MarinaService>();
      services.AddScoped<IMarinaRepository, MarinaRepository>();
      services.AddScoped<ICharterService, CharterService>();
      services.AddScoped<ICharterRepository, CharterRepository>();
      services.AddScoped<IExpenseService, ExpenseService>();
      services.AddScoped<IExpenseRepository, ExpenseRepository>();
      services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
      services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
      services.AddScoped<IFixtureService, FixtureService>();
      services.AddScoped<IFixtureRepository, FixtureRepository>();
      services.AddScoped<ISettingsService, SettingsService>();
      services.AddScoped<ISettingsRepository, SettingsRepository>();

      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddTransient<IMapper, Mapper>();
    }
  }
}
