using AutoMapper;
using Cms.Mapping;
using Cms.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cms.WebApi
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
      services.AddAutoMapper(typeof(MappingProfile));

      ConfigurationOptions.ConfigureService(services, Configuration);

      // IOC containers 
      IocContainerConfiguration.ConfigureService(services, Configuration);

      // JWT containers 
      JwtConfiguration.ConfigureService(services, Configuration);

      // Swagger API documentation
      SwaggerConfiguration.ConfigureService(services);

      // Cors Orgin 
      CorsOrginConfiguration.ConfigureService(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseAuthentication();
      app.UseAuthorization();
      app.UseRouting(); // must be below app.UseAuthentication();
      //app.UseMvc(); // .net core < 3.0

      SwaggerConfiguration.Configure(app);

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
