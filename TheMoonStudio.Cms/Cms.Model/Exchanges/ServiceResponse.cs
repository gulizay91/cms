using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Cms.Model.Exchanges
{
  [Serializable]
  public class ServiceResponse<T>
  {
    public bool HasExceptionError { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    public List<T> DataList { get; set; }

    [JsonProperty]
    public T Data { get; set; }

    public int Count { get; set; }

    public bool IsValid => !HasExceptionError && /*!ValidationErrorList.Any() && */string.IsNullOrEmpty(Message);

    public bool IsSuccessful { get; set; }

    public int ResultCode { get; set; }

    public ServiceResponse(HttpContext context = null)
    {
      DataList = new List<T>();
      ResultCode = (int)HttpStatusCode.OK;
      IsSuccessful = true;
      Message = "İşlem başarılı bir şekilde gerçekleşmiştir.";
    }
  }
}
