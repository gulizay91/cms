using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.WebApi.Configuration
{
  public static class ConfigurationOptions
  {
    /// <summary>
    /// Configures the service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
      //services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
      //services.Configure<MultiTenancy>(configuration.GetSection("MultiTenancy"));
    }
  }
}
