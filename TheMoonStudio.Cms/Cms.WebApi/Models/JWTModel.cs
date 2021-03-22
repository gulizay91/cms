using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.WebApi.Models
{
  public class JWTModel
  {
    public static string _jwtKey = "eab13OIsj+BXE99/090f274bjk1903///THEMOON-STUDIO-SECRET-KEY///+5f2GA01d8bg19913759GA3tgyes45jl-bN03Ks21193431==";
    public static string _jwtIssuer = "http://www.themoon-studio.com";
    public static int _jwtExpireDays = 1;
    public static int _jwtTimeMinute = 1440;

    public string SecretKey { get { return _jwtKey; } set { } }
    public string Issuer { get { return _jwtIssuer; } set { } }
    public int ExpireDays { get { return _jwtExpireDays; } set { } }
    public int TimeMinute { get { return _jwtTimeMinute; } set { } }
  }
}
