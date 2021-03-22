using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  [Serializable]
  public class ServiceRequest<T> : BaseRequest
  {
    [JsonProperty]
    public T Model { get; set; }
    public int Key { get; set; }
    public string Value { get; set; }
    public int? CompanyId { get; set; }
    //public bool? AllActive { get; set; }

  }
}
