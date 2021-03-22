using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cms.WebApi.Configuration
{
  public static class SwaggerConfiguration
  {
    /// <summary>
    /// Configures the service.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void ConfigureService(IServiceCollection services)
    {
      // Swagger API documentation
      // Register the Swagger generator, defining one or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
        new OpenApiInfo
        {
          Title = "CMS WEB API",
          Description = "This ASP.NET Core Web API for Charter Management System",
          TermsOfService = new Uri("https://example.com/terms"),
          Contact = new OpenApiContact
          {
            Name = "Güliz AY",
            Email = "gulizay91@gmail.com",
            Url = new Uri("https://twitter.com/GlizAY"),
          },
          License = new OpenApiLicense
          {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
          }
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          In = ParameterLocation.Header,
          Description = "Please insert JWT with Bearer into field. Example: \"Authorization: Bearer {token}\"",
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey
        });

        // for new swagger 1.1.0 => 2.4.0
        //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
        //        { "Bearer", Enumerable.Empty<string>() },
        //        { "Basic", new string[]{ } },
        //});

        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    /// <summary>
    /// Configures the specified application.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void Configure(IApplicationBuilder app)
    {
      // This will redirect default url to Swagger url
      var option = new RewriteOptions();
      option.AddRedirect("^$", "swagger");
      app.UseRewriter(option);

      app.UseStaticFiles();

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();
      //app.UseSwagger(c =>
      //{
      //  c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
      //});

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS WEB API V1.0");
        //c.InjectStylesheet("../Content/Swagger/custom.css");
      });
    }
  }
}
