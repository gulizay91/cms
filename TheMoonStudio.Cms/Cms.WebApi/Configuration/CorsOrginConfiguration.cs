using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.WebApi.Configuration
{
  public static class CorsOrginConfiguration
  {
    /// <summary>
    /// Adds localization support for the applicatin
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureService(IServiceCollection services)
    {
      //add permission enable cross-origin requests (CORS) from angular
      var corsBuilder = new CorsPolicyBuilder();
      corsBuilder.AllowAnyHeader();
      corsBuilder.AllowAnyMethod();
      corsBuilder.AllowAnyOrigin();
      corsBuilder.AllowCredentials();

      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll", corsBuilder.Build());
      });
    }
  }
}
