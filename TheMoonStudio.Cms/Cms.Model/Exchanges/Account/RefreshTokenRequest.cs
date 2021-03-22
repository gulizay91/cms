using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class RefreshTokenRequest
  {
    public Guid TenantId { get; set; }
    public string RefreshToken { get; set; }
  }
}
