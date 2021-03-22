using Cms.Model.ViewModels;
using Cms.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cms.WebApi.Helpers
{
  public static class JwtManager
  {
    public static Tuple<string, string> CreateToken(TokenModel model, int expireMinutes = 0)
    {
      string tokenString = "";
      string tokenRefresh = CreateRefreshToken(model.Username);

      try
      {
        //Set issued at date
        DateTime issuedAt = DateTime.UtcNow;

        if (expireMinutes <= 0)
          expireMinutes = JWTModel._jwtTimeMinute;

        //set the time when it expires
        DateTime expires = DateTime.UtcNow.AddMinutes(expireMinutes);

        var tokenHandler = new JwtSecurityTokenHandler();

        //create a identity and add claims to the user which we want to log in
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                    {
                      new Claim(ClaimTypes.Name, model.Username),
                      new Claim(ClaimTypes.Email, model.Email),
                      //new Claim("TenantId", user.TenantId.ToString()),
                      new Claim("UserId", model.UserId.ToString()),
                      new Claim("Username", model.Username.ToString()),
                      new Claim("CompanyId", model.CompanyId.ToString()),
                      new Claim("UserTypeId", model.UserTypeId.ToString()),
                      new Claim("FullName", model.FullName),
                      new Claim("RefreshToken", tokenRefresh)
                  });

        // add user rights to inside claims
        //if (user.UserRights != null)
        //{
        //  var arrUserRights = user.UserRights.Where(x => x.IsActive).Select(r => r.RightName).ToList().ToArray();
        //  claimsIdentity.AddClaim(new Claim("UserRights", String.Join(",", arrUserRights)));
        //}
        
        if (model.Settings != null)
        {
          // TODO: cache'e alinacak.
        }

        var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(JWTModel._jwtKey));
        var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

        //create the jwt
        var token = tokenHandler.CreateJwtSecurityToken(issuer: JWTModel._jwtIssuer, audience: JWTModel._jwtIssuer, //  api path, sadece sifreleme icin (adres dogrulugu onemli degil)
                    subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);

        tokenString = tokenHandler.WriteToken(token);
      }
      catch (Exception)
      {
        tokenString = "";
      }

      Tuple<string, string> response = Tuple.Create(tokenString, tokenRefresh);

      return response;
    }

    public static string CreateRefreshToken(string UserName)
    {
      string refreshToken = "";
      try
      {
        string refreshTokenKey = JWTModel._jwtKey + ":" + UserName + ":" + Guid.NewGuid().ToString();
        refreshToken = SHACryptoManager.GenerateSHA256String(refreshTokenKey);
      }
      catch (Exception)
      {

      }

      return refreshToken;
    }

  }
}
