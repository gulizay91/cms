using Cms.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Cms.WebApi.Configuration
{
  public static class JwtConfiguration
  {
    /// <summary>
    /// Configures the service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
    {
      #region JWT
      var now = DateTime.UtcNow;
      var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(JWTModel._jwtKey));

      // ===== Add Jwt Authentication ========
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(cfg =>
      {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
          ValidAudience = JWTModel._jwtIssuer,
          ValidIssuer = JWTModel._jwtIssuer,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          //LifetimeValidator = this.LifetimeValidator,
          IssuerSigningKey = securityKey
        };
      });
      #endregion

    }
  }
}
