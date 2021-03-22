using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class BaseRequest
  {
    public Guid ClientTenantId { get; set; }
    public int ClientUserId { get; set; }
    public string ClientUsername { get; set; }
  }
}
